using SearchEngine.API.Core.Domain.Entity;
using SearchEngine.API.Core.Domain.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngine.API.Core.ApplicationServices {
	public interface IDocumentService {
		Task<PaginationResponse<IEnumerable<Document>>> GetByTerm(string termValue, PaginationRequest paginationRequest);
	}
}
