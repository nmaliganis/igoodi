namespace igoodi.receiver360.common.infrastructure.Helpers.ResourceParameters
{
    public abstract class BaseResourceParameters
    {
        /// <summary>
        /// <param name="SortDirection">asc/desc, default:asc</param>
        /// </summary>
        public string SortDirection { get; set; } = "asc";

        private const int MaxPageSize = 30;
        /// <summary>
        /// <param name="PageIndex">Optional. Index of Page</param>
        /// </summary>

        public virtual int? PageIndex { get; set; } = -1;

        private int _pageSize = -1;
        /// <summary>
        /// <param name="PageSize">Optional. Size of Page</param>
        /// </summary>
        public virtual int? PageSize
        {
            get => _pageSize;
            set => _pageSize = (int) ((value > MaxPageSize) ? MaxPageSize : value);
        }

        public abstract string Filter { get; set; }
        public abstract string SearchQuery { get; set; }
        public abstract string OrderBy { get; set; }

        public abstract string Fields { get; set; }
    }
}
