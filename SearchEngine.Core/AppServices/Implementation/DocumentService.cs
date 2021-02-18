using SearchEngine.Core.DomainServices;
using SearchEngine.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchEngine.Core.AppServices.Implementation
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepo _repo;

        public DocumentService(IDocumentRepo repo)
        {
            _repo = repo;
        }

        public Response Search(Request request)
        {
            if (string.IsNullOrEmpty(request.Term))
            {
                throw new ArgumentException("Term cannot be null or empty.");
            }

            var documents = _repo.Search(request.Term);

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

        public Document GetById(string id) => _repo.GetById(id);

        public IEnumerable<Document> GetDocumentsFromDocTable()
        {
            var documents = _repo.GetDocumentsFromDocTable();
            return documents;
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
