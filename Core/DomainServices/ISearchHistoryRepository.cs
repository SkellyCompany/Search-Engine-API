using SearchEngine.API.Core.Domain.Entity;
using System.Collections.Generic;


namespace SearchEngine.API.Core.DomainServices {
	public interface ISearchHistoryRepository {
		IEnumerable<SearchHistoryRecord> GetAll();
		SearchHistoryRecord Add(SearchHistoryRecord searchHistory);
		SearchHistoryRecord Edit(SearchHistoryRecord searchHistory);
		bool Delete(string keyword);
	}
}
