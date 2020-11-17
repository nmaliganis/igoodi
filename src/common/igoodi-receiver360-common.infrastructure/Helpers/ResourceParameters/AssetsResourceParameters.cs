namespace igoodi.receiver360.common.infrastructure.Helpers.ResourceParameters
{
    public class AssetsResourceParameters : BaseResourceParameters
    {
        /// <summary>
        /// <param name="Filter">Filter in Field
        /// (id, firstname, lastname, email e.t.c.)</param>
        /// </summary>
        public override string Filter { get; set; }
        /// <summary>
        /// <param name="SearchQuery">Search into Fields
        /// (id, firstname, lastname, email e.t.c.)</param>
        /// </summary> 
        public override string SearchQuery { get; set; }
        /// <summary>
        /// <param name="Fields">Fields to be Shown
        /// (id, firstname, lastname, email e.t.c.)</param>
        /// </summary>
        public override string Fields { get; set; }
        /// <summary>
        /// <param name="OrderBy">Order by specific field 
        /// (id, firstname, lastname, email, default: lastname)</param>
        /// </summary> 
        public override string OrderBy { get; set; } = "name";
    }
}