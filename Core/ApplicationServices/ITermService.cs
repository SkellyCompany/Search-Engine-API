using SearchEngine.API.Core.Entity;
using System.Threading.Tasks;

namespace SearchEngine.API.Core.ApplicationServices
{
    public interface ITermService
    {
        Task<Response> Search(Request request);
    }
}
