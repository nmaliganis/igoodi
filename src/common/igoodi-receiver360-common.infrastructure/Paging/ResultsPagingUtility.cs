using System;
using igoodi.receiver360.common.infrastructure.Constants;

namespace igoodi.receiver360.common.infrastructure.Paging
{
    public static class ResultsPagingUtility
    {
        private const string ValueLessThanOneErrorMessage = "Value may not be less than 1.";
        private const string ValueLessThanZeroErrorMessage = "Value may not be less than 0.";

        public static int CalculatePageSize(int requestedValue, int maxValue)
        {
            if (requestedValue < 1)
                throw new ArgumentOutOfRangeException(nameof(requestedValue), requestedValue, ValueLessThanOneErrorMessage);
            if (maxValue < 1)
                throw new ArgumentOutOfRangeException(nameof(maxValue), maxValue, ValueLessThanOneErrorMessage);

            var boundedPageSize = Math.Min(requestedValue, maxValue);
            return boundedPageSize;
        }

        public static int CalculateStartIndex(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(ConstantValues.CommonParameterNames.PageNumber, pageNumber,
                    ValueLessThanOneErrorMessage);
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(ConstantValues.CommonParameterNames.PageSize, pageSize,
                    ValueLessThanOneErrorMessage);

            int startIndex = (pageNumber - 1) * pageSize;
            return startIndex;
        }

        public static int CalculatePageCount(int totalItemCount, int pageSize)
        {
            if (totalItemCount < 0)
                throw new ArgumentOutOfRangeException(nameof(totalItemCount), totalItemCount, ValueLessThanZeroErrorMessage);
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(ConstantValues.CommonParameterNames.PageSize, pageSize,
                    ValueLessThanOneErrorMessage);

            var totalPageCount = (totalItemCount + pageSize - 1) / pageSize;
            return totalPageCount;
        }
    }
}