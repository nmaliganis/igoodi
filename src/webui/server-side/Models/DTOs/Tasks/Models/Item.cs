using System.Collections.Generic;

namespace igoodi.receiver360.webui.Models.DTOs.Tasks.Models
{
  public class Item
  {
    public Item()
    {
      this.Voucher = new Voucher();
      this.ScanProcessType = new ScanProcessType();
    }

    public long Id { get; set; }
    public string Code { get; set; }
    public Voucher Voucher { get; set; }
    public ScanProcessType ScanProcessType { get; set; }
    public long TotalTasks { get; set; }
    public CurrentTask CurrentTask { get; set; }
    public long CurrentTaskNumber { get; set; }
    public string ScanUrl { get; set; }
    public BucketReference BucketReference { get; set; }
    public string StartDate { get; set; }
    public object EndDate { get; set; }
    public string UpdateDate { get; set; }
    public object DeleteDate { get; set; }
    public ItemItemDescription ItemDescription { get; set; }
    public List<CurrentTask> TasksHistory { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsLastTask { get; set; }
  }
}