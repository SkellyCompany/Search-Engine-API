using System.Collections.Generic;
using SearchEngine.API.Core.Domain.Entity;

namespace SearchEngine.API.Core.Domain.Pagination
{
    public class Response
    {
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<DocumentInTerm> Documents { get; set; }
    }
}
