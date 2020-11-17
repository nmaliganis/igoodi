using System.Linq;
using System.Threading.Tasks;
using igoodi.receiver360.common.dtos.Vms.Assets;
using igoodi.receiver360.common.infrastructure.Extensions;
using igoodi.receiver360.common.infrastructure.Helpers.ResourceParameters;
using igoodi.receiver360.common.infrastructure.Paging;
using igoodi.receiver360.common.infrastructure.PropertyMappings;
using igoodi.receiver360.common.infrastructure.TypeMappings;
using igoodi.receiver360.contracts.Assets;
using igoodi.receiver360.model.Assets;
using igoodi.receiver360.repository.ContractRepositories;

namespace igoodi.receiver360.services.Assets
{
  public class InquiryAllAssetsProcessor : IInquiryAllAssetsProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly IAssetRepository _assetRepository;
    private readonly IPropertyMappingService _propertyMappingService;

    public InquiryAllAssetsProcessor(IAutoMapper autoMapper,
      IAssetRepository assetRepository, IPropertyMappingService propertyMappingService)
    {
      _autoMapper = autoMapper;
      _assetRepository = assetRepository;
      _propertyMappingService = propertyMappingService;
    }

    public Task<PagedList<Asset>> GetCategoriesAsync(AssetsResourceParameters categoriesResourceParameters)
    {
      var collectionBeforePaging =
        QueryableExtensions.ApplySort(_assetRepository
            .FindAllCategoriesPagedOf(categoriesResourceParameters.PageIndex,
              categoriesResourceParameters.PageSize), 
          categoriesResourceParameters.OrderBy, 
          _propertyMappingService.GetPropertyMapping<AssetUiModel, Asset>());


      if (!string.IsNullOrEmpty(categoriesResourceParameters.SearchQuery))
      {
        // trim & ignore casing
        var searchQueryForWhereClause = categoriesResourceParameters.SearchQuery
          .Trim().ToLowerInvariant();

        collectionBeforePaging.QueriedItems = collectionBeforePaging.QueriedItems
          .Where(a => a.Name.ToLowerInvariant().Contains(searchQueryForWhereClause));
      }

      return Task.Run(() => PagedList<Asset>.Create(collectionBeforePaging,
        categoriesResourceParameters.PageIndex,
        categoriesResourceParameters.PageSize));
    }
  }
}