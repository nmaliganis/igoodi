using AutoMapper;
using igoodi.receiver360.common.dtos.Vms.Assets;
using igoodi.receiver360.model.Assets;

namespace igoodi.receiver360.api.Configurations.AutoMappingProfiles.Assets
{
    public class AssetForModificationUiModelToAssetEntityAutoMapperProfile : Profile
    {
        public AssetForModificationUiModelToAssetEntityAutoMapperProfile()
        {
            ConfigureMapping();
        }

        public void ConfigureMapping()
        {
            CreateMap<AssetForModificationUiModel, Asset>()
                .ForMember(dest => dest.Name, opt => 
                  opt.MapFrom(src => src.AssetName))
                .MaxDepth(1)
                .PreserveReferences()
                ;
        }
    }
}