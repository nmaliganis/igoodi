using System;

namespace igoodi.receiver360.webui.Models.DTOs.Tasks.Models
{
  public class WardrobeAsset
  {
    public long Id { get; set; }
    public string Code { get; set; }
    public Uri ImageUrl { get; set; }
    public Uri Url { get; set; }
    public long Price { get; set; }
    public string Currency { get; set; }
    public WardrobeType WardrobeType { get; set; }
    public WardrobeCategory WardrobeCategory { get; set; }
    public object Partner { get; set; }
    public object Size { get; set; }
    public object Os { get; set; }
    public object OsVersion { get; set; }
    public object CompressionType { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime DeleteDate { get; set; }
    public ScanTypeItemDescription ItemDescription { get; set; }
    public bool IsPurchased { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsCompressed { get; set; }
  }
}