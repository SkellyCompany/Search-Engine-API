using SearchEngine.API.Core.Domain.Pagination;
using SearchEngine.API.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchEngine.API.Core.Domain.Entity;

namespace SearchEngine.API.Core.ApplicationServices.Services {
	public class DocumentService : IDocumentService {
		private readonly ITermRepository _repository;

		public DocumentService(ITermRepository repository) {
			_repository = repository;
		}

		public async Task<PaginationResponse<IEnumerable<Document>>> GetByTerm(string termValue, PaginationRequest paginationRequest) {
			if (string.IsNullOrEmpty(termValue)) {
				throw new ArgumentException("Term cannot be null or empty.");
			}
			var documents = await _repository.GetTermDocuments(termValue);
			if (documents == null || documents.Count() == 0) {
				var response = new PaginationResponse<IEnumerable<Document>>() { Data = new List<Document>() };
				return response;
			}
			if (paginationRequest is not null && paginationRequest.PageCount is not 0 && paginationRequest.PageNumber is not 0 && paginationRequest.PageSize is not 0) {
				Console.WriteLine(paginationRequest.PageCount);
				var response = new PaginationResponse<IEnumerable<Document>>() {
					Data = documents.Skip((paginationRequest.PageNumber - 1) * paginationRequest.PageSize).Take(paginationRequest.PageSize),
					PageNumber = paginationRequest.PageNumber,
					PageCount = paginationRequest.PageCount,
					PageSize = paginationRequest.PageSize,
				};
				return response;
			} else {
				Console.WriteLine(documents.Count());
				var response = new PaginationResponse<IEnumerable<Document>>() { Data = documents };
				return response;
			}
		}
	}
}
