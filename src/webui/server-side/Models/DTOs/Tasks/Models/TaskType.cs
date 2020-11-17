using System.Collections.Generic;

namespace igoodi.receiver360.webui.Models.DTOs.Tasks.Models
{
  public class TaskType
  {
    public long Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Colour { get; set; }
    public List<OperatorRole> OperatorRoles { get; set; }
    public object ScanProcessTypes { get; set; }
    public string UpdateDate { get; set; }
    public object DeleteDate { get; set; }
    public bool Automatic { get; set; }
    public bool IsDeleted { get; set; }
  }
}