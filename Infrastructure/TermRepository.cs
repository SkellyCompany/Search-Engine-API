using MongoDB.Driver;
using SearchEngine.API.Core.DomainServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchEngine.API.Infrastructure.Client;
using SearchEngine.API.Core.Domain.Entity;

namespace SearchEngine.API.Infrastructure {
	public class TermRepository : ITermRepository {
		private readonly IClient _client;

		public TermRepository(IClient client) {
			_client = client;
		}

		public async Task<IEnumerable<Document>> GetTermDocuments(string term) {
			var terms = await _client
				.TermsCollection
				.Find(t => t.Value == term)
				.ToListAsync();
			var res = terms.FirstOrDefault();
			if (res != null) {
				return res.Documents;
			} else {
				return null;
			}
		}
	}
}
