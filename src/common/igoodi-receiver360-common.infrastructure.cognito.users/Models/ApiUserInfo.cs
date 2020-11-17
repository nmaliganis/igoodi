using System.Collections.Generic;

namespace igoodi.receiver360.common.infrastructure.cognito.users.Models
{
    /// <summary>
    ///    User registration information
    /// </summary>
    public class ApiUserInfo
    {
        public string Name { get; set; }
        public string Status { get; set; }
        // 
        public Dictionary<string,string> Attributes { get; set; }
    }
}
