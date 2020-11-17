namespace igoodi.receiver360.webui.Models.DTOs.Tasks.Models
{
  public class CurrentTask
  {
    public long Id { get; set; }
    public TaskType TaskType { get; set; }
    public string Code { get; set; }
    public long Status { get; set; }
    public long StatusQuality { get; set; }
    public long PositionInList { get; set; }
    public string Note { get; set; }
    public OperatorInCharge OperatorInCharge { get; set; }
    public object Reviewer { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public bool Automatic { get; set; }
    public string DeleteDate { get; set; }
    public bool IsAutoAssigned { get; set; }
    public bool IsAutoAssignedReviewer { get; set; }
    public bool IsDeleted { get; set; }
  }
}