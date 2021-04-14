using SearchEngine.API.Core.Domain.Entity;
using System.Collections.Generic;


namespace SearchEngine.API.Core.DomainServices {
	public interface ISearchHistoryRepository {
		IEnumerable<SearchHistoryRecord> GetAll();
		SearchHistoryRecord Create(SearchHistoryRecord searchHistory);
		SearchHistoryRecord Update(SearchHistoryRecord searchHistory);
		bool Delete(string keyword);
	}
}
