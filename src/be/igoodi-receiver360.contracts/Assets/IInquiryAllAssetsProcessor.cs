using System.Threading.Tasks;
using igoodi.receiver360.common.infrastructure.Helpers.ResourceParameters;
using igoodi.receiver360.common.infrastructure.Paging;
using igoodi.receiver360.model.Assets;

namespace igoodi.receiver360.contracts.Assets
{
  public interface IInquiryAllAssetsProcessor
  {
    Task<PagedList<Asset>> GetCategoriesAsync(AssetsResourceParameters assetsResourceParameters);
  }
}