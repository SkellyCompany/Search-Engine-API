using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SearchEngine.API.Core.Entity
{
    public class Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("url")]
        public string Url { get; set; }
    }
}
