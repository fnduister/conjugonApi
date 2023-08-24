using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ConjugonApi.Models.Common
{
    public record EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
    }
}
