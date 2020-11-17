using System.Collections.Generic;

namespace igoodi.receiver360.common.infrastructure.cognito.users.Models
{
    /// <summary>
    ///    User registration information
    /// </summary>
    public class ApiRegisterRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EMail { get; set;  }
        // 
        public Dictionary<string,string> Attributes { get; set; }
    }
}
