using SearchEngine.API.Core.Domain.Entity;
using SearchEngine.API.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchEngine.API.Core.ApplicationServices.Services {
	public class SearchHistoryService : ISearchHistoryService {
		private ISearchHistoryRepository _searchHistoryRepository;

		public SearchHistoryService(ISearchHistoryRepository searchHistoryRepository) {
			_searchHistoryRepository = searchHistoryRepository;
		}

		public void DeleteAsync(string keyword) {
			_searchHistoryRepository.Delete(keyword);
		}

		public IEnumerable<string> Read(string keyword, int maxAmount = 10) {
			IEnumerable<SearchHistoryRecord> searchHistories = _searchHistoryRepository.GetAll();

			//If no keyword string exists
			if (keyword == null || keyword == "") {
				List<string> strings = new List<string>();
				foreach (var item in searchHistories.
					OrderByDescending(search => search.Dates.Count).
					ThenByDescending(search => search.Dates[search.Dates.Count - 1]).
					Take(maxAmount).ToList()) {
					strings.Add(item.Term);
				};
				return strings;
			}

			//Else if there is a keyword.
			else {
				List<string> strings = new List<string>();
				foreach (SearchHistoryRecord searchHistory in searchHistories) {
					if (searchHistory.Term.ToLower().Contains(keyword.ToLower())) {
						strings.Add(searchHistory.Term);
						if (strings.Count == maxAmount) {
							break;
						}
					}
				}
				return strings;
			}
		}

		public void SaveAsync(string keyword) {
			IEnumerable<SearchHistoryRecord> searchHistories = _searchHistoryRepository.GetAll();
			SearchHistoryRecord search = null;
			foreach (SearchHistoryRecord searchHistory in searchHistories) {
				if (searchHistory.Term.ToLower().Equals(keyword.ToLower())) {
					search = searchHistory;
					break;
				}
			}

			if (search == null) {
				search = new SearchHistoryRecord();
				search.Dates = new List<DateTime>();
				search.Dates.Add(DateTime.Now);
				search.Term = keyword;
				_searchHistoryRepository.Add(search);
			} else {
				search.Dates.Add(DateTime.Now);
				_searchHistoryRepository.Edit(search);
			}
		}
	}
}
