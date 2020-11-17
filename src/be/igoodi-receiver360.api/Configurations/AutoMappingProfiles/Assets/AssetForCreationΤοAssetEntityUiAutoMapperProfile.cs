using AutoMapper;
using igoodi.receiver360.common.dtos.Vms.Assets;
using igoodi.receiver360.model.Assets;

namespace igoodi.receiver360.api.Configurations.AutoMappingProfiles.Assets
{
  public class AssetForCreationΤοAssetEntityUiAutoMapperProfile : Profile
  {
    public AssetForCreationΤοAssetEntityUiAutoMapperProfile()
    {
      ConfigureMapping();
    }

    public void ConfigureMapping()
    {
      CreateMap<AssetForCreationUiModel, Asset>()
        .ForMember(dest => dest.Name, 
          opt => opt.MapFrom(src => src.AssetName))
        .MaxDepth(1)
        .PreserveReferences()
        ;
    }
  }
}