using SearchEngine.Core.Entity;
using System.Threading.Tasks;

namespace SearchEngine.Core.ApplicationServices
{
    public interface ITermService
    {
        Task<Response> Search(Request request);
    }
}
