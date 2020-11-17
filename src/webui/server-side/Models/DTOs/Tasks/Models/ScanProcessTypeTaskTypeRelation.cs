namespace igoodi.receiver360.webui.Models.DTOs.Tasks.Models
{
  public class ScanProcessTypeTaskTypeRelation
  {
    public long Id { get; set; }
    public TaskType TaskType { get; set; }
    public long PositionInList { get; set; }
  }
}