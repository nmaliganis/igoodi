using System;
using System.Threading.Tasks;
using igoodi.receiver360.common.dtos.Vms.Assets;
using igoodi.receiver360.common.infrastructure.TypeMappings;
using igoodi.receiver360.common.infrastructure.UnitOfWorks;
using igoodi.receiver360.contracts.Assets;
using igoodi.receiver360.repository.ContractRepositories;

namespace igoodi.receiver360.services.Assets
{
    public class UpdateAssetProcessor : IUpdateAssetProcessor
    {
        private readonly IUnitOfWork _uOf;
        private readonly IAssetRepository _assetRepository;
        private readonly IAutoMapper _autoMapper;
        public UpdateAssetProcessor(IUnitOfWork uOf, IAutoMapper autoMapper, IAssetRepository assetRepository)
        {
            _uOf = uOf;
            _assetRepository = assetRepository;
            _autoMapper = autoMapper;
        }

        public Task<AssetUiModel> UpdateAssetAsync(AssetForModificationUiModel updatedAsset)
        {
            throw new NotImplementedException();
        }
    }
}