using agendamedica.Data;
using agendamedica.Iservice;
using MongoDB.Driver;

namespace agendamedica.Service
{
    public class PacienteService : IPacienteService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Paciente> _pacienteTable = null;
        public PacienteService() {
            _mongoClient = new MongoClient("mongodb://localhost:27017/");
            _database = _mongoClient.GetDatabase("CLinica");
            _pacienteTable = _database.GetCollection<Paciente>("Paciente");
        }
        public string Delete(string pacienteId)
        {
            _pacienteTable.DeleteOne(x=>x.Id==pacienteId);
            return "Deleted";
        }

        public Paciente GetPaciente(string pacienteId)
        {
            return _pacienteTable.Find(x=>x.Id == pacienteId).FirstOrDefault();
        }

        public List<Paciente> GetPacientes()
        {
            return _pacienteTable.Find(FilterDefinition<Paciente>.Empty).ToList();
        }

        public void SaveOrUpdate(Paciente paciente)
        {
            var pacienteObj = _pacienteTable.Find(x=>x.Id==paciente.Id).FirstOrDefault();
            if (pacienteObj == null) 
            {
                _pacienteTable.InsertOne(paciente);
            }
            else
            {
                _pacienteTable.ReplaceOne(x => x.Id == pacienteObj.Id, paciente);
            }
        }
    }
}
