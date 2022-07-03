using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Monogotodo.Shared;

namespace Monogotodo.Data.Models
{
    public class Monogoto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; }
        
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