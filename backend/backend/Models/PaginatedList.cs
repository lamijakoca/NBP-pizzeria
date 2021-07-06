using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class PaginatedList
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        //public int TotalPages { get; set; }

        public PaginatedList()
        {
            this.PageSize = 3;
            this.PageNumber = 1;
        }
        public PaginatedList(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 3 ? 3 : pageSize;
        }
    }
}
