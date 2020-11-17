using System;
using System.ComponentModel.DataAnnotations;

namespace igoodi.receiver360.webui.Models.DTOs.Assets
{
  public class AssetDto
  {
    [Key] public Guid Id { get; set; }

    public string Message { get; set; }
    [Required]
    [Editable(true)]
    public virtual string AssetName { get; set; }
  }
}