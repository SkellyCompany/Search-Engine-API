using System;
using System.Collections.Generic;

namespace SearchEngine.API.Core.Domain.Entity
{
	public class SearchHistory
	{
		public string Keyword { get; set; }
		public List<DateTime> Dates { get; set; }
	}
}
