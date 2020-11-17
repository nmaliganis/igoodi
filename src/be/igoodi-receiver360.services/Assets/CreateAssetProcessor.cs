using System;
using System.Linq;
using System.Threading.Tasks;
using igoodi.receiver360.common.dtos.Vms.Assets;
using igoodi.receiver360.common.infrastructure.Exceptions.Domain.Assets;
using igoodi.receiver360.common.infrastructure.TypeMappings;
using igoodi.receiver360.common.infrastructure.UnitOfWorks;
using igoodi.receiver360.contracts.Assets;
using igoodi.receiver360.model.Assets;
using igoodi.receiver360.repository.ContractRepositories;
using Serilog;

namespace igoodi.receiver360.services.Assets
{
  public class CreateAssetProcessor : ICreateAssetProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly IAssetRepository _assetRepository;
    private readonly IAutoMapper _autoMapper;

    public CreateAssetProcessor(IUnitOfWork uOf, IAutoMapper autoMapper, IAssetRepository assetRepository)
    {
      _uOf = uOf;
      _assetRepository = assetRepository;
      _autoMapper = autoMapper;
    }

    public Task<AssetUiModel> CreateAssetAsync(Guid accountIdToCreateThisAsset,
      AssetForCreationUiModel newAssetUiModel)
    {
      var response =
        new AssetUiModel()
        {
          Message = "START_CREATION"
        };

      if (newAssetUiModel == null)
      {
        response.Message = "ERROR_INVALID_ASSET_MODEL";
        return Task.Run(() => response);
      }

      try
      {
        var assetToBeCreated = _autoMapper.Map<Asset>(newAssetUiModel);

        assetToBeCreated.InjectWithAudit(accountIdToCreateThisAsset);

        ThrowExcIfAssetCannotBeCreated(assetToBeCreated);
        ThrowExcIfThisAssetAlreadyExist(assetToBeCreated);

        Log.Debug(
          $"Create Asset: {newAssetUiModel.AssetName}" +
          "--CreateAsset--  @NotComplete@ [CreateAssetProcessor]. " +
          "Message: Just Before MakeItPersistence");

        MakeAssetPersistent(assetToBeCreated);

        Log.Debug(
          $"Create Asset: {newAssetUiModel.AssetName}" +
          "--CreateAsset--  @Complete@ [CreateAssetProcessor]. " +
          "Message: Just After MakeItPersistence");
        response = ThrowExcIfAssetWasNotBeMadePersistent(assetToBeCreated);
        response.Message = "SUCCESS_CREATION";
      }
      catch (InvalidAssetException e)
      {
        response.Message = "ERROR_INVALID_Asset_MODEL";
        Log.Error(
          $"Create Asset: {newAssetUiModel.AssetName}" +
          "--CreateAsset--  @NotComplete@ [CreateAssetProcessor]. " +
          $"Broken rules: {e.BrokenRules}");
      }
      catch (AssetAlreadyExistsException ex)
      {
        response.Message = "ERROR_Asset_ALREADY_EXISTS";
        Log.Error(
          $"Create Asset: {newAssetUiModel.AssetName}" +
          "--CreateAsset--  @fail@ [CreateAssetProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (AssetDoesNotExistAfterMadePersistentException exx)
      {
        response.Message = "ERROR_Asset_NOT_MADE_PERSISTENT";
        Log.Error(
          $"Create Asset: {newAssetUiModel.AssetName}" +
          "--CreateAsset--  @fail@ [CreateAssetProcessor]." +
          $" @innerfault:{exx?.Message} and {exx?.InnerException}");
      }
      catch (Exception exxx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Create Asset: {newAssetUiModel.AssetName}" +
          $"--CreateAsset--  @fail@ [CreateAssetProcessor]. " +
          $"@innerfault:{exxx.Message} and {exxx.InnerException}");
      }

      return Task.Run(() => response);
    }

    private void MakeAssetPersistent(Asset assetToBeCreated)
    {
      _assetRepository.Save(assetToBeCreated);
      _uOf.Commit();
    }

    private AssetUiModel ThrowExcIfAssetWasNotBeMadePersistent(Asset assetToBeCreated)
    {
      var retrievedAsset = _assetRepository.FindByName(assetToBeCreated.Name);
      if (retrievedAsset != null)
        return _autoMapper.Map<AssetUiModel>(retrievedAsset);
      throw new AssetDoesNotExistAfterMadePersistentException(assetToBeCreated.Name);
    }

    private void ThrowExcIfThisAssetAlreadyExist(Asset assetToBeCreated)
    {
      var customerRetrieved = _assetRepository.FindByName(assetToBeCreated.Name);
      if (customerRetrieved != null)
      {
        throw new AssetAlreadyExistsException(assetToBeCreated.Name,
          assetToBeCreated.GetBrokenRulesAsString());
      }
    }

    private void ThrowExcIfAssetCannotBeCreated(Asset assetToBeCreated)
    {
      bool canBeCreated = !assetToBeCreated.GetBrokenRules().Any();
      if (!canBeCreated)
        throw new InvalidAssetException(assetToBeCreated.GetBrokenRulesAsString());
    }
  }
}
