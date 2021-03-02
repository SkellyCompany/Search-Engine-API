using SearchEngine.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngine.Core.DomainServices
{
    public interface ITermRepository
    {
        Task<IEnumerable<DocumentInTerm>> Search(string term);
    }
}
