namespace igoodi.receiver360.webui.Models.DTOs.Tasks.Models
{
  public class BucketReference
  {
    public long Id { get; set; }
    public string BucketType { get; set; }
    public string BucketName { get; set; }
    public string Region { get; set; }
    public object ServerSideEncryption { get; set; }
    public string EntityName { get; set; }
    public string EntityClass { get; set; }
    public object BucketRelativePath { get; set; }
    public bool Versioning { get; set; }
    public bool Mapping { get; set; }
    public bool Public { get; set; }
  }
}