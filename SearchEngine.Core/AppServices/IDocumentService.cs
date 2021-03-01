using SearchEngine.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngine.Core.AppServices
{
    public interface IDocumentService
    {
        Task<Document> GetById(string id);
        Task<IEnumerable<Document>> GetDocumentsFromDocTable();
    }
}
