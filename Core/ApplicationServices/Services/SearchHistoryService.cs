using SearchEngine.API.Core.Domain.Entity;
using SearchEngine.API.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchEngine.API.Core.ApplicationServices.Services
{
	public class SearchHistoryService : ISearchHistoryService
	{
		private ISearchHistoryRepository _searchHistoryRepository;
		private int _defaultMaxAmount = 10;


		public SearchHistoryService(ISearchHistoryRepository searchHistoryRepository)
		{
			_searchHistoryRepository = searchHistoryRepository;
		}

		public void DeleteKeywordFromHistory(string keyword)
		{
            _searchHistoryRepository.Delete(keyword);
		}

		public IEnumerable<string> GetHistory(string keyword, int maxAmount = 10)
		{
            IEnumerable<SearchHistory> searchHistories = _searchHistoryRepository.GetAll();

            //Since "Nothing" / "null" for an int, is 0 a 0 check is placed here to replace the int 
            //with a default max amount for the class.
            if (maxAmount == 0)
            {
                maxAmount = _defaultMaxAmount;
            }

            //If no keyword string exists
            if (keyword == null || keyword == "")
            {
                List<string> strings = new List<string>();
                foreach (var item in searchHistories.
                    OrderByDescending(search => search.Dates.Count).
                    ThenByDescending(search => search.Dates[search.Dates.Count - 1]).
                    Take(maxAmount).ToList())
                {
                    strings.Add(item.Keyword);
                };
                return strings;
            }

            //Else if there is a keyword. 
            else
            {
                List<string> strings = new List<string>();
                foreach (SearchHistory searchHistory in searchHistories)
                {
                    if (searchHistory.Keyword.ToLower().Contains(keyword.ToLower()))
                    {
                        strings.Add(searchHistory.Keyword);
                        if (strings.Count == maxAmount)
                        {
                            break;
                        }
                    }
                }
                return strings;
            }
        }

		public void SaveHistory(string keyword)
		{
            IEnumerable<SearchHistory> searchHistories = _searchHistoryRepository.GetAll();
            SearchHistory search = null;
            foreach (SearchHistory searchHistory in searchHistories)
            {
                if (searchHistory.Keyword.ToLower().Equals(keyword.ToLower()))
                {
                    search = searchHistory;
                    break;
                }
            }

            if (search == null)
            {
                search = new SearchHistory();
                search.Dates = new List<DateTime>();
                search.Dates.Add(DateTime.Now);
                search.Keyword = keyword;
                _searchHistoryRepository.Add(search);
            }
            else
            {
                search.Dates.Add(DateTime.Now);
                _searchHistoryRepository.Edit(search);
            }
        }
	}
}
