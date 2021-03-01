using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace SearchEngine.Core.Entity
{
    public class DocumentInTerm
    {
        public string docId { get; set; }
        [BsonElement("url")]
        public string Url { get; set; }
        [BsonElement("occurence")]
        public int Occurence { get; set; }
    }
}
