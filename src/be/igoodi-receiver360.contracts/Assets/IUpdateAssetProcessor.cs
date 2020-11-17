using System.Threading.Tasks;
using igoodi.receiver360.common.dtos.Vms.Assets;

namespace igoodi.receiver360.contracts.Assets
{
    public interface IUpdateAssetProcessor
    {
        Task<AssetUiModel> UpdateAssetAsync(AssetForModificationUiModel updatedAsset);
    }
}
