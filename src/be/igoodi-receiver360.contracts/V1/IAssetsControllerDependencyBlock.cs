using igoodi.receiver360.contracts.Assets;

namespace igoodi.receiver360.contracts.V1
{
    public interface IAssetsControllerDependencyBlock
    {
        ICreateAssetProcessor CreateAssetProcessor { get; }
        IInquiryAssetProcessor InquiryAssetProcessor { get; }
        IUpdateAssetProcessor UpdateAssetProcessor { get; }
        IInquiryAllAssetsProcessor InquiryAllAssetsProcessor { get; }
        IDeleteAssetProcessor DeleteAssetProcessor { get; }
    }
}