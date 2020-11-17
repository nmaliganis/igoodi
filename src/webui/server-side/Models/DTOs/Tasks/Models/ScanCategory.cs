using System;
using System.Collections.Generic;

namespace igoodi.receiver360.webui.Models.DTOs.Tasks.Models
{
  public class ScanCategory
  {
    public long Id { get; set; }
    public string Code { get; set; }
    public Uri ImageUrl { get; set; }
    public object Pedestal { get; set; }
    public DateTime UpdateDate { get; set; }
    public object DeleteDate { get; set; }
    public ScanTypeItemDescription ItemDescription { get; set; }
    public bool IsDeleted { get; set; }
    public object Package { get; set; }
    public List<WardrobeAsset> WardrobeAssets { get; set; }
  }
}