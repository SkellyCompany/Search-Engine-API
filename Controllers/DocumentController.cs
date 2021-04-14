using Microsoft.AspNetCore.Mvc;
using SearchEngine.API.Core.ApplicationServices;
using SearchEngine.API.Core.Domain.Entity;
using SearchEngine.API.Core.Domain.Pagination;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngine.API.Controllers {
	[Route("[controller]")]
	[ApiController]
	public class DocumentController : Controller {
		private readonly IDocumentService _documentService;

		public DocumentController(IDocumentService documentService) {
			_documentService = documentService;
		}

		[HttpGet]
		public async Task<ActionResult<List<Document>>> GetByTerm([FromQuery] string term, [FromQuery] PaginationRequest request) {
			var result = await _documentService.GetByTerm(term, request);
			return Ok(result.Data);
		}
	}
}
