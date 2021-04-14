using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace SearchEngine.API.Core.Domain.Entity {

	public class SearchHistoryRecord {
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("term")]
		public string Term { get; set; }

		[BsonElement("dates")]
		public List<DateTime> Dates { get; set; }
	}
}
