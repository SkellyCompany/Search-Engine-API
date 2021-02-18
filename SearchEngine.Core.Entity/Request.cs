using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Core.Entity
{
    public class Request
    {
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public string Term { get; set; }
    }
}
