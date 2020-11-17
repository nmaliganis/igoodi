using System.ComponentModel.DataAnnotations;

namespace igoodi.receiver360.webui.Models.DTOs.Assets
{
    public class AssetForModificationDto
    {
        [Key] public int Id { get; set; }
        public string Message { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string AssetName { get; set; }
    }
}