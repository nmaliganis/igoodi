using System.Collections.Generic;

namespace igoodi.receiver360.webui.Models.DTOs.Tasks.Models
{
  public class Voucher
  {
    public Voucher()
    {
      this.ScanType = new ScanType();
    }
    public long Id { get; set; }
    public string VoucherCode { get; set; }
    public long Status { get; set; }
    public ScanType ScanType { get; set; }
    public VoucherWardrobePackage WardrobePackage { get; set; }
    public List<object> WardrobeAvatarArtifacts { get; set; }
    public object Partner { get; set; }
    public string CreatedAt { get; set; }
    public string ExpiryDate { get; set; }
    public string GateProcessedAt { get; set; }
    public string UpdateDate { get; set; }
    public string DeleteDate { get; set; }
    public User User { get; set; }
    public Dictionary<string, long?> BodyData { get; set; }
    public string Code { get; set; }
    public object Artifact { get; set; }
    public bool IsPaid { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsProcessed { get; set; }
  }
}