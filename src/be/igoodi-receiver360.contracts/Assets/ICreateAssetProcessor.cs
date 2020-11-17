using System;
using System.Threading.Tasks;
using igoodi.receiver360.common.dtos.Vms.Assets;

namespace igoodi.receiver360.contracts.Assets
{
  public interface ICreateAssetProcessor
  {
    Task<AssetUiModel> CreateAssetAsync(Guid accountIdToCreateThisAsset, AssetForCreationUiModel newAssetUiModel);
  }
}