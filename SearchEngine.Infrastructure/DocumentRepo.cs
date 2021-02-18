using MongoDB.Driver;
using SearchEngine.Core.DomainServices;
using SearchEngine.Core.Entity;
using System.Collections.Generic;
using System.Linq;

namespace SearchEngine.Infrastructure
{
    public class DocumentRepo : IDocumentRepo
    {
        private readonly IClient _client;
        public DocumentRepo(IClient client)
        {
            _client = client;
        }

        public IEnumerable<DocumentInTerm> Search(string term)
        {
            var terms = _client.GetTerms();
            var res = terms.Find(t => t.Value == term).FirstOrDefault();
            return res.Documents;
        }

        public IEnumerable<Document> GetDocumentsFromDocTable() => _client.GetDocuments().Find(_ => true).ToList();

        public Document GetById(string id) => _client.GetDocuments().Find(doc => doc.Id == id).FirstOrDefault();
    }
}
