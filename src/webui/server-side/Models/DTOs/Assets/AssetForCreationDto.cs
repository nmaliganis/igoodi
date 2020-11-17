using System.ComponentModel.DataAnnotations;

namespace igoodi.receiver360.webui.Models.DTOs.Assets
{
  public class AssetForCreationDto
  {
    [Required(AllowEmptyStrings = false)]
    [Editable(true)]
    public string Name { get; set; }
  }
}