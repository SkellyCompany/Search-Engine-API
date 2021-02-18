﻿using System.Collections.Generic;

namespace SearchEngine.Core.Entity
{
    public class Response
    {
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<DocumentInTerm> Documents { get; set; }
    }
}
