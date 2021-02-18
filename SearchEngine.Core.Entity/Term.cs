﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace SearchEngine.Core.Entity
{
    public class Term
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("value")]
        public string Value { get; set; }
        [BsonElement("documents")]
        public IEnumerable<DocumentInTerm> Documents { get; set; }
    }
}
