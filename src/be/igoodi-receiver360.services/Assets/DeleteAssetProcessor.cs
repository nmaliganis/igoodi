using System;
using System.Threading.Tasks;
using igoodi.receiver360.common.dtos.Vms.Assets;
using igoodi.receiver360.common.infrastructure.UnitOfWorks;
using igoodi.receiver360.contracts.Assets;
using igoodi.receiver360.repository.ContractRepositories;

namespace igoodi.receiver360.services.Assets
{
    public class DeleteAssetProcessor : IDeleteAssetProcessor
    {
        private readonly IUnitOfWork _uOf;
        private readonly IAssetRepository _assetRepository;

        public DeleteAssetProcessor(IUnitOfWork uOf,
            IAssetRepository AssetRepository)
        {
            _uOf = uOf;
            _assetRepository = AssetRepository;
        }

        public Task DeleteAssetAsync(Guid assetToBeDeletedId)
        {
            throw new NotImplementedException();
        }

        public Task<AssetForDeletionUiModel> SoftDeleteAssetAsync(Guid userAuditId, Guid id)
        {
          throw new NotImplementedException();
        }

        public Task<AssetForDeletionUiModel> HardDeleteAssetAsync(Guid userAuditId, Guid id)
        {
          throw new NotImplementedException();
        }
    }
}