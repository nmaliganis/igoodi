using System.ComponentModel.DataAnnotations;

namespace igoodi.receiver360.common.dtos.Vms.Assets
{
    public class AssetForCreationUiModel
    {
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string AssetName { get; set; }
    }
}
