using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace SearchEngine.API.Core.Entity
{
    public class DocumentInTerm
    {
        public string docId { get; set; }
        [BsonElement("url")]
        public string Url { get; set; }
        [BsonElement("occurrences")]
        public int Occurrences { get; set; }
    }
}
