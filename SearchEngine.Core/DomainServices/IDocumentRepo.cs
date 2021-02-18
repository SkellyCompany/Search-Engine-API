using SearchEngine.Core.Entity;
using System.Collections.Generic;

namespace SearchEngine.Core.DomainServices
{
    public interface IDocumentRepo
    {
        IEnumerable<DocumentInTerm> Search(string term);
        Document GetById(string id);
        IEnumerable<Document> GetDocumentsFromDocTable();
    }
}
