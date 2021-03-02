using SearchEngine.Core.DomainServices;
using SearchEngine.Core.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngine.Core.ApplicationServices.Services
{
    public class TermService : ITermService
    {
        private readonly ITermRepository _repository;

        public TermService(ITermRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Search(Request request)
        {
            if (string.IsNullOrEmpty(request.Keyword))
            {
                throw new ArgumentException("Term cannot be null or empty.");
            }

            var documents = await _repository.Search(request.Keyword);

            if (documents == null)
            {
                return null;
            }

            if (!IsAll(request))
            {
                var response = new Response() { PageNumber = request.PageNumber, PageCount = request.PageCount, PageSize = request.PageSize, Documents = documents };
                return GetPaginatedResults(response);
            }
            else
            {
                var response = new Response() { Documents = documents };
                return response;
            }
        }

        // Determines whether all request needed or not.
        private bool IsAll(Request request)
        {
            return request.PageCount > 0 && request.PageNumber > 0 && request.PageSize > 0;
        }

        private Response GetPaginatedResults(Response data)
        {
            if (data.PageNumber < 1)
                data.PageNumber = 1;
            if (data.PageSize < 1)
                data.PageSize = 12;

            data.Documents = data.Documents.Skip((data.PageNumber - 1) * data.PageSize).Take(data.PageSize);

            return data;
        }
    }
}
