using MongoDB.Driver;
using SearchEngine.Core.DomainServices;
using SearchEngine.Core.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchEngine.Infrastructure.Client;
using SearchEngine.Infrastructure.Client.Database;

namespace SearchEngine.Infrastructure
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
