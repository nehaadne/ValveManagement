using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValveManagement.Common.Models
{
    public class Pagination
    {
        public int PageNo { get; set; }
        public int TotalPages { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
    }
}
