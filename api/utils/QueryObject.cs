using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.utils
{
    public class QueryObject
    {
        public string? Symbol { get; set; } = null;
        public string? CompanyName { get; set; } = null;
        public string? SortBy { get; set; } = "Symbol";
        public bool IsDescending { get; set; } = false;
        public int Limit { get; set; } = 2;
        public int Number { get; set; } = 1;
    }
}