using System.Collections.Generic;
using System.Threading.Tasks;
using SearchEngine.API.Core.Domain.Entity;

namespace SearchEngine.API.Core.DomainServices
{
    public interface IDocumentRepository
    {
        Task<Document> GetById(string id);
        Task<IEnumerable<Document>> GetDocumentsFromDocTable();
    }
}
