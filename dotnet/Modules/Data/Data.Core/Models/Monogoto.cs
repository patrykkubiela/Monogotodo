using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Monogotodo.Shared;

namespace Data.Core.Models
{
    public class Monogoto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        
        [BsonElement("name")]
        public string Name { get; set; }
        
        [BsonElement("description")]
        public string Description { get; set; }
        
        [BsonElement("type")]
        public MonogotoType Type { get; set; }
        
        [BsonElement("broadcaster")]
        public Monogoto Broadcaster { get; set; }
        
        [BsonElement("observers")]
        public ICollection<Monogoto> Observers { get; }
    }
}