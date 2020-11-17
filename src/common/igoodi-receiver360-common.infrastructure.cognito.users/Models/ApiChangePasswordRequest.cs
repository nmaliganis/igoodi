namespace igoodi.receiver360.common.infrastructure.cognito.users.Models
{
    public class ApiChangePasswordRequest
    {
        public string UserName { get; set; }
        public string PreviewPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
