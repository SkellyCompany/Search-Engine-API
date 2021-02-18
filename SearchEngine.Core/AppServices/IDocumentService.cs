using SearchEngine.Core.Entity;
using System.Collections.Generic;

namespace SearchEngine.Core.AppServices
{
    public interface IDocumentService
    {
        Response Search(Request request);
        Document GetById(string id);
        IEnumerable<Document> GetDocumentsFromDocTable();
    }
}
