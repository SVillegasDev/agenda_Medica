using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace agendamedica.Data
{
    public class Paciente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } 
        public string Nombre { get; set; } 
        public string Apellido { get; set; } 
        public int Edad { get; set; } 
        public DateTime FechaNacimiento { get; set; } 
    }
}
