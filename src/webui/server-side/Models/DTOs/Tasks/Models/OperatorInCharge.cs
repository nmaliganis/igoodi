using System.Collections.Generic;

namespace igoodi.receiver360.webui.Models.DTOs.Tasks.Models
{
  public class OperatorInCharge
  {
    public long Id { get; set; }
    public string Email { get; set; }
    public string Nickname { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public object BirthDate { get; set; }
    public string Team { get; set; }
    public string Office { get; set; }
    public object StartDate { get; set; }
    public long TasksDoneCount { get; set; }
    public string CreatedAt { get; set; }
    public string LastLoginDate { get; set; }
    public List<OperatorRole> OperatorRoles { get; set; }
    public string ActivatedAt { get; set; }
    public object DeactivatedAt { get; set; }
    public string UpdateDate { get; set; }
    public object DeleteDate { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActivated { get; set; }
  }
}