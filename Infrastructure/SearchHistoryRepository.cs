using SearchEngine.API.Core.Domain.Entity;
using SearchEngine.API.Core.DomainServices;
using SearchEngine.API.Infrastructure.Client;
using System.Collections.Generic;
using MongoDB.Driver;

namespace SearchEngine.API.Infrastructure
{
	public class SearchHistoryRepository : ISearchHistoryRepository
	{
		private readonly IClient _client;

		public SearchHistoryRepository(IClient client)
		{
			_client = client;
		}

		public SearchHistory Add(SearchHistory searchHistory)
		{
			_client.SearchHistoryCollection.InsertOne(searchHistory);
			return searchHistory;
		}

		public bool Delete(string keyword)
		{
			return _client.SearchHistoryCollection.DeleteOne(k => k.Keyword == keyword).IsAcknowledged;
		}

		public SearchHistory Edit(SearchHistory searchHistory)
		{
			FilterDefinition<SearchHistory> filter = Builders<SearchHistory>.Filter.Eq("keyword", searchHistory.Keyword);
			UpdateDefinition<SearchHistory> update = Builders<SearchHistory>.Update.Push(sh => sh.Dates, searchHistory.Dates[0]);
			_client.SearchHistoryCollection.UpdateOne(filter, update);
			return searchHistory;
		}

		public IEnumerable<SearchHistory> GetAll()
		{
			return _client.SearchHistoryCollection.Find(_ => true).ToList();
		}
	}
}
