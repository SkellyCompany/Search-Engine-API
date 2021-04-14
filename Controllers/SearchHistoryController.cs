using Microsoft.AspNetCore.Mvc;
using SearchEngine.API.Core.ApplicationServices;
using System.Collections.Generic;

namespace SearchEngine.API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class SearchHistoryController : ControllerBase
	{
		private readonly ISearchHistoryService _searchHistoryService;

		public SearchHistoryController(ISearchHistoryService searchHistoryService)
		{
			_searchHistoryService = searchHistoryService;
		}

		[HttpGet()]
		public IActionResult GetHistory([FromQuery] string keyword, [FromQuery] int maxAmount)
        {
            IEnumerable<string> searchHistory = _searchHistoryService.GetHistory(keyword, maxAmount);
			return Ok(searchHistory);
		}

		[HttpPost()]
		public IActionResult SaveHistory([FromQuery] string keyword)
		{
			_searchHistoryService.SaveHistory(keyword);
			return Ok();
		}

		[HttpDelete()]
		public IActionResult DeleteHistory([FromQuery] string keyword)
		{
			_searchHistoryService.DeleteKeywordFromHistory(keyword);
			return Ok();
		}
	}
}
