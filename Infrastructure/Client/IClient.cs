using MongoDB.Driver;
using SearchEngine.API.Core.Domain.Entity;

namespace SearchEngine.API.Infrastructure.Client {
	public interface IClient {
		IMongoDatabase Database { get; }
		IMongoCollection<Term> TermsCollection { get; }
		IMongoCollection<SearchHistoryRecord> SearchHistoryCollection { get; }
	}
}
