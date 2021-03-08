using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.API.Core.Entity
{
    public class Request
    {
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public string Keyword { get; set; }
    }
}
