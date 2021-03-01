using SearchEngine.Core.Entity;
using System.Threading.Tasks;

namespace SearchEngine.Core.AppServices
{
    public interface ITermService
    {
        Task<Response> Search(Request request);
    }
}
