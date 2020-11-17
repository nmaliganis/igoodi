using System.Collections.Generic;

namespace igoodi.receiver360.webui.Models.DTOs.Tasks.Models
{
  public class ScanProcessType
  {
    public long Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ScanDestinationUrl { get; set; }
    public BucketReference BucketReferenceDestination { get; set; }
    public string UpdateDate { get; set; }
    public object DeleteDate { get; set; }
    public List<ScanType> ScanTypes { get; set; }
    public List<ScanProcessTypeTaskTypeRelation> ScanProcessTypeTaskTypeRelations { get; set; }
    public bool IsDeleted { get; set; }
  }
}