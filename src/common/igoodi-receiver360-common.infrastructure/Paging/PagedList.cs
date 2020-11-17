using System;
using System.Collections.Generic;
using System.Linq;
using igoodi.receiver360.common.infrastructure.Domain.Queries;

namespace igoodi.receiver360.common.infrastructure.Paging
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPrevious => (CurrentPage > 1);

        public bool HasNext => (CurrentPage < TotalPages);

        public PagedList(List<T> items, int count, int? pageNumber = -1, int? pageSize = -1)
        {
            TotalCount = count;
            PageSize = (int)pageSize;
            CurrentPage = (int)pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static PagedList<T> Create(QueryResult<T> source, int? pageNumber, int? pageSize)
        {
            int count = 0;
            if (pageNumber != -1 || pageSize != -1)
                count = source.TotalPageCount;

            var items = source.QueriedItems.ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}