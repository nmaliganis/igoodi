using System;
using System.Threading.Tasks;
using igoodi.receiver360.common.dtos.Vms.Assets;
using igoodi.receiver360.common.infrastructure.TypeMappings;
using igoodi.receiver360.contracts.Assets;
using igoodi.receiver360.repository.ContractRepositories;

namespace igoodi.receiver360.services.Assets
{
  public class InquiryAssetProcessor : IInquiryAssetProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly IAssetRepository _AssetRepository;

    public InquiryAssetProcessor(IAssetRepository AssetRepository, IAutoMapper autoMapper)
    {
      _AssetRepository = AssetRepository;
      _autoMapper = autoMapper;
    }

    public Task<AssetUiModel> GetAssetByIdAsync(Guid id)
    {
      return Task.Run(() => _autoMapper.Map<AssetUiModel>(_AssetRepository.FindBy(id)));
    }

    public Task<AssetUiModel> GetAssetByEmailAsync(string email)
    {
      //return Task.Run(() => _autoMapper.Map<AssetUiModel>(_AssetRepository.FindAssetByEmail(email)));
      return null;
    }

    public Task<bool> SearchIfAnyAssetByEmailOrLoginExistsAsync(string email, string login)
    {
      //return Task.Run(() =>  _AssetRepository.FindAssetByEmailOrLogin(email, login).Count > 0);
      return null;
    }
  }
}