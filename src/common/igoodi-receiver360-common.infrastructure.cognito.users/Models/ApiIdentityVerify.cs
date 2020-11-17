namespace igoodi.receiver360.common.infrastructure.cognito.users.Models
{
    /// <summary>
    ///    Represents the result of an identity operation.
    /// </summary>
    public class ApiIdentityVerify
    {
        /// <summary>
        ///    UserName
        /// </summary>
        public string User { get; set; } = "";
        /// <summary>
        ///  Identity Token for verify
        /// </summary>
        public string Token { get;  set; } = "";


        /// <summary>
        ///    Converts the value of the current ApiIdentityVerify 
        ///     object to its equivalent string representation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
                  return $"UserName: {User}, Token: {Token}";
        }
    }
}