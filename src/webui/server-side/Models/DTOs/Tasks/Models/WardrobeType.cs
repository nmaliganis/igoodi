using System;

namespace igoodi.receiver360.webui.Models.DTOs.Tasks.Models
{
  public class WardrobeType
  {
    public long Id { get; set; }
    public string Code { get; set; }
    public DateTime UpdateDate { get; set; }
    public object DeleteDate { get; set; }
    public object ItemDescription { get; set; }
    public bool IsDeleted { get; set; }
  }
}