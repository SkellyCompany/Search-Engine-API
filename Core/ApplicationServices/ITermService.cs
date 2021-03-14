using SearchEngine.API.Core.Domain.Pagination;
using System.Threading.Tasks;

namespace SearchEngine.API.Core.ApplicationServices
{
    public interface ITermService
    {
        Task<Response> Search(Request request);
    }
}
