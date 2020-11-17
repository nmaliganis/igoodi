using System.Collections.Generic;

namespace igoodi.receiver360.common.infrastructure.cognito.users.Models
{
    /// <summary>
    ///    User update user information
    /// </summary>
    public class ApiUpdateRequest
    {
        public string UserName { get; set; }
        // 
        public Dictionary<string,string> Attributes { get; set; }
    }
}
