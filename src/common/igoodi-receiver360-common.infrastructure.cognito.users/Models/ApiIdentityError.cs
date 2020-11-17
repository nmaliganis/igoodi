namespace igoodi.receiver360.common.infrastructure.cognito.users.Models
{
    public class ApiIdentityError
    {
        //
        // Summary:
        //     Gets or sets the code for this error.
        public int Code { get; set; } = 0;
        //
        // Summary:
        //     Gets or sets the description for this error.
        public string Description { get; set; } = "";
        /// <summary>
        ///    Converts the value of the current ApiIdentityError 
        ///     object to its equivalent string representation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Code == 0) { return "OK"; }
            return $"Failed: {Code} , {Description}";
        }
    }
}