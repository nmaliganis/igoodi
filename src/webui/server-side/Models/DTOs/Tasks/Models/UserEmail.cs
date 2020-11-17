namespace igoodi.receiver360.webui.Models.DTOs.Tasks.Models
{
  public class UserEmail
  {
    public long Id { get; set; }
    public string Email { get; set; }
    public string ActivatedAt { get; set; }
    public object DeactivatedAt { get; set; }
    public object ChangeEmailToken { get; set; }
    public string TokenGenerationDate { get; set; }
    public bool IsVerified { get; set; }
    public bool IsActivated { get; set; }
  }
}