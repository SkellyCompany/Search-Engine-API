using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchEngine.API.Core.ApplicationServices;

namespace SearchEngine.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _service;

        public DocumentController(IDocumentService service)
        {
            _service = service;
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _service.GetById(id);
            if (result != null)
                return Ok(result);
            else
                //return BadRequest(new { Message = "Greg, seriously?" });
                return NoContent();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllDocumentsFromDocTable()
        {
            var result = await _service.GetDocumentsFromDocTable();
            if (result.Any())
                return Ok(result);
            else
                //return BadRequest(new { Message = "That's not how you do it Greg..." });
                return NoContent();
        }
    }
}
