using SearchEngine.API.Core.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngine.API.Core.DomainServices {
	public interface ITermRepository {
		Task<IEnumerable<Document>> GetTermDocuments(string termValue);
	}
}
