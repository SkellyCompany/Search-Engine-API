using SearchEngine.API.Core.Domain.Entity;
using System.Collections.Generic;


namespace SearchEngine.API.Core.DomainServices
{
	public interface ISearchHistoryRepository
	{
		IEnumerable<SearchHistory> GetAll();
		SearchHistory Add(SearchHistory searchHistory);
		SearchHistory Edit(SearchHistory searchHistory);
		bool Delete(string keyword);
	}
}
