using AutoMapper;
using igoodi.receiver360.common.dtos.Vms.Assets;
using igoodi.receiver360.model.Assets;

namespace igoodi.receiver360.api.Configurations.AutoMappingProfiles.Assets
{
    public class AssetEntityToAssetUiAutoMapperProfile : Profile
    {
        public AssetEntityToAssetUiAutoMapperProfile()
        {
            ConfigureMapping();
        }

        public void ConfigureMapping()
        {
            CreateMap<Asset, AssetUiModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.Name))
                .MaxDepth(1)
                .PreserveReferences()
                ;
            
        }
    }
}