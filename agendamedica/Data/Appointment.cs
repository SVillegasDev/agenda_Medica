using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace agendamedica.Data
{
    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime Start { get; set; } 
        public DateTime End { get; set; }
        public string PaNombre { get; set; }
        public string PaApellidoPa { get; set; }
        public string PaApellidoMa { get; set; }
        public string Rut { get; set; }
        public string EspecialistaId { get; set; }
        public string Area { get; set; }
        public string EsNombre{ get; set; }
        public string EsApellido { get; set; }
        public string EsRut { get; set; }

    }
}
