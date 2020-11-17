using System;
using System.Threading.Tasks;
using igoodi.receiver360.common.dtos.Vms.Assets;

namespace igoodi.receiver360.contracts.Assets
{
    public interface IDeleteAssetProcessor
    {
        Task DeleteAssetAsync(Guid assetToBeDeletedId);
        Task<AssetForDeletionUiModel> SoftDeleteAssetAsync(Guid userAuditId, Guid id);
        Task<AssetForDeletionUiModel> HardDeleteAssetAsync(Guid userAuditId, Guid id);
    }
}