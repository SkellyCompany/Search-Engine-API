using SearchEngine.API.Core.Domain.Entity;
using SearchEngine.API.Core.DomainServices;
using SearchEngine.API.Infrastructure.Client;
using System.Collections.Generic;
using MongoDB.Driver;

namespace SearchEngine.API.Infrastructure {
	public class SearchHistoryRepository : ISearchHistoryRepository {
		private readonly IClient _client;

		public SearchHistoryRepository(IClient client) {
			_client = client;
		}

		public SearchHistoryRecord Create(SearchHistoryRecord searchHistory) {
			_client.SearchHistoryCollection.InsertOne(searchHistory);
			return searchHistory;
		}

		public bool Delete(string keyword) {
			return _client.SearchHistoryCollection.DeleteOne(k => k.Term == keyword).IsAcknowledged;
		}

		public SearchHistoryRecord Update(SearchHistoryRecord searchHistory) {
			FilterDefinition<SearchHistoryRecord> filter = Builders<SearchHistoryRecord>.Filter.Eq("keyword", searchHistory.Term);
			UpdateDefinition<SearchHistoryRecord> update = Builders<SearchHistoryRecord>.Update.Set("dates", searchHistory.Dates);
			_client.SearchHistoryCollection.UpdateOne(filter, update);
			return searchHistory;
		}

		public IEnumerable<SearchHistoryRecord> GetAll() {
			return _client.SearchHistoryCollection.Find(_ => true).ToList();
		}
	}
}
