using System;
using System.ComponentModel.DataAnnotations;
using igoodi.receiver360.common.dtos.Vms.Bases;

namespace igoodi.receiver360.common.dtos.Vms.Assets
{
    public class AssetUiModel : IUiModel
    {
        [Key]
        public Guid Id { get; set; }
        [Editable(true)]
        public string Message { get; set; }

    
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string AssetName { get; set; }
    }
}
