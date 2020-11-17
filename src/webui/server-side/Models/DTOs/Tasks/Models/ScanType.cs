using System;

namespace igoodi.receiver360.webui.Models.DTOs.Tasks.Models
{
  public class ScanType
  {
    public long Id { get; set; }
    public string Code { get; set; }
    public Uri ImageUrl { get; set; }
    public double Price { get; set; }
    public string Currency { get; set; }
    public ScanCategory ScanCategory { get; set; }
    public object Partner { get; set; }
    public ScanTypeWardrobePackage WardrobePackage { get; set; }
    public long Duration { get; set; }
    public string ExpiryDate { get; set; }
    public bool Rigging { get; set; }
    public string UpdateDate { get; set; }
    public object DeleteDate { get; set; }
    public ScanTypeItemDescription ItemDescription { get; set; }
    public bool IsDeleted { get; set; }
  }
}