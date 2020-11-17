using System;
using System.ComponentModel.DataAnnotations;

namespace igoodi.receiver360.common.dtos.Vms.Bases
{
    public interface IUiModel
    {
        [Key]
        Guid Id { get; set; }
        [Editable(false)]
        string Message { get; set; }
    }
}
