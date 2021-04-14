﻿using MongoDB.Driver;
using SearchEngine.API.Core.Domain.Entity;

namespace SearchEngine.API.Infrastructure.Client
{
    public interface IClient
    {
        IMongoDatabase Database { get; }
        IMongoCollection<Document> DocumentsCollection { get; }
        IMongoCollection<Term> TermsCollection { get; }
        IMongoCollection<SearchHistory> SearchHistoryCollection { get; }
    }
}
