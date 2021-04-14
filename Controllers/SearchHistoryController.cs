using Microsoft.AspNetCore.Mvc;
using SearchEngine.API.Core.ApplicationServices;
using System.Collections.Generic;

namespace SearchEngine.API.Controllers {
	[Route("[controller]")]
	[ApiController]
	public class SearchHistoryController : ControllerBase {
		private readonly ISearchHistoryService _searchHistoryService;

		public SearchHistoryController(ISearchHistoryService searchHistoryService) {
			_searchHistoryService = searchHistoryService;
		}

		[HttpGet()]
		public IActionResult Get([FromQuery] string keyword, [FromQuery] int maxAmount) {
			IEnumerable<string> searchHistory = _searchHistoryService.Read(keyword, maxAmount);
			return Ok(searchHistory);
		}

		[HttpPost()]
		public IActionResult Save([FromQuery] string keyword) {
			_searchHistoryService.SaveAsync(keyword);
			return Ok();
		}

		[HttpDelete()]
		public IActionResult Delete([FromQuery] string keyword) {
			_searchHistoryService.DeleteAsync(keyword);
			return Ok();
		}
	}
}
