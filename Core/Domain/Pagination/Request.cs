namespace SearchEngine.API.Core.Domain.Pagination
{
    public class Request
    {
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public string Keyword { get; set; }
    }
}
