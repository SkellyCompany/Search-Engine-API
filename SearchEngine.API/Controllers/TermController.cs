using Microsoft.AspNetCore.Mvc;
using SearchEngine.Core.AppServices;
using SearchEngine.Core.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngine.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TermController : Controller
    {
        private readonly ITermService _service;

        public TermController(ITermService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDocumentsForASpecificTerm([FromQuery] Request request)
        {
            var result = await _service.Search(request);
            if (result != null && result.Documents.Any())
                return Ok(result);
            else
                //return BadRequest(new { Message = "Aww, come on Greg..." });
                return NoContent();
        }
    }
}
