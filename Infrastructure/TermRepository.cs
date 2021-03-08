using MongoDB.Driver;
using SearchEngine.API.Core.DomainServices;
using SearchEngine.API.Core.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchEngine.API.Infrastructure.Client;

namespace SearchEngine.API.Infrastructure
{
    public class TermRepository : ITermRepository
    {
        private readonly IClient _client;

        public TermRepository(IClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<DocumentInTerm>> Search(string term)
        {
            var terms = await _client
                .TermsCollection
                .Find(t => t.Value == term)
                .ToListAsync();
            var res = terms.FirstOrDefault();
            if (res != null) 
            {
                return res.Documents;
            }
            else 
            {
                return null;
            }
        }
    }
}
