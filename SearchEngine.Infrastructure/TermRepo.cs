using MongoDB.Driver;
using SearchEngine.Core.DomainServices;
using SearchEngine.Core.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngine.Infrastructure
{
    public class TermRepo : ITermRepo
    {
        private readonly IClient _client;

        public TermRepo(IClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<DocumentInTerm>> Search(string term)
        {
            var terms = _client.GetTerms();
            var ts = await terms.Find(t => t.Value == term).ToListAsync();
            var res = ts.FirstOrDefault();
            if (res != null)
                return res.Documents;
            else
                return null;
        }
    }
}
