using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace SearchEngine.API.Core.Domain.Entity {
	public class Document {
		public string docId { get; set; }
		[BsonElement("url")]
		public string Url { get; set; }
		[BsonElement("occurrences")]
		public int Occurrences { get; set; }
	}
}
