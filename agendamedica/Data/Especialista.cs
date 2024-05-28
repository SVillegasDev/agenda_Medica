using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace agendamedica.Data
{
    public class Especialista
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Especialidad { get; set; }
        public string Rut { get; set; }
    }
}
