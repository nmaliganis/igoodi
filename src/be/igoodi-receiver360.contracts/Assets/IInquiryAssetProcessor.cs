using System;
using System.Threading.Tasks;
using igoodi.receiver360.common.dtos.Vms.Assets;

namespace igoodi.receiver360.contracts.Assets
{
    public interface IInquiryAssetProcessor
    {
        Task<AssetUiModel> GetAssetByIdAsync(Guid id);
        Task<AssetUiModel> GetAssetByEmailAsync(string email);
        Task<bool> SearchIfAnyAssetByEmailOrLoginExistsAsync(string email, string login);
    }
}