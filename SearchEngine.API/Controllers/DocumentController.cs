using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SearchEngine.Core.AppServices;
using SearchEngine.Core.Entity;

namespace SearchEngine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _service;

        public DocumentController(IDocumentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllDocumentsForASpecificTerm([FromQuery] Request request)
        {
            var result = _service.Search(request);
            if (result.Documents.Any())
                return Ok(result);
            else
                //return BadRequest(new { Message = "Aww, come on Greg..." });
                return NoContent();
        }

        [HttpGet("{id:length(24)}")]
        public IActionResult GetById(string id)
        {
            var result = _service.GetById(id);
            if (result != null)
                return Ok(result);
            else
                //return BadRequest(new { Message = "Greg, seriously?" });
                return NoContent();
        }

        [HttpGet("all")]
        public IActionResult GetAllDocumentsFromDocTable()
        {
            var result = _service.GetDocumentsFromDocTable();
            if (result.Any())
                return Ok(result);
            else
                //return BadRequest(new { Message = "That's not how you do it Greg..." });
                return NoContent();
        }
    }
}
