using SearchEngine.API.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngine.API.Core.DomainServices
{
    public interface IDocumentRepository
    {
        Task<Document> GetById(string id);
        Task<IEnumerable<Document>> GetDocumentsFromDocTable();
    }
}
