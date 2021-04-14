using Microsoft.AspNetCore.Mvc;
using SearchEngine.API.Core.ApplicationServices;
using SearchEngine.API.Core.Domain.Pagination;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngine.API.Controllers {
	[Route("[controller]")]
	[ApiController]
	public class TermController : Controller {
		private readonly ITermService _service;

		public TermController(ITermService service) {
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllDocumentsForASpecificTerm([FromQuery] Request request) {
			var result = await _service.Search(request);
			return Ok(result.Documents);
		}
	}
}
