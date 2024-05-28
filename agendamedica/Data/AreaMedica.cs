using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace agendamedica.Data
{
    public class AreaMedica
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }  
        public string Nombre { get; set; }
    }
}
