using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queires
{
    public class EmployeeQueryParameters
    {
        private int _pageNumber = 1;
        private int _pageSize = 5;
        private const int MaxPageSize = 100;

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = value <= 0 ? 1 : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value <= 0) _pageSize = 5;
                else if (value > MaxPageSize) _pageSize = MaxPageSize;
                else _pageSize = value;
            }
        }

        /// <summary>Search by employee name (contains)</summary>
        public string? Search { get; set; }

        /// <summary>"name" or "salary"</summary>
        public string? SortBy { get; set; }

        public bool Desc { get; set; } = false;
    }
}
