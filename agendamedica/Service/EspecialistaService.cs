using agendamedica.Data;
using agendamedica.Iservice;
using MongoDB.Driver;

namespace agendamedica.Service
{
    public class EspecialistaService : IEspecialistaService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Especialista> _especialistaTable = null;
        public EspecialistaService()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017/");
            _database = _mongoClient.GetDatabase("CLinica");
            _especialistaTable = _database.GetCollection<Especialista>("Especialista");
        }

        public string Delete(string especialistaId)
        {
            _especialistaTable.DeleteOne(x => x.Id == especialistaId);
            return "Deleted";
        }

        public Especialista GetEspecialista(string especialistaId)
        {
            return _especialistaTable.Find(x=>x.Id==especialistaId).FirstOrDefault();
        }

        public List<Especialista> GetEspecialista()
        {
            return _especialistaTable.Find(FilterDefinition<Especialista>.Empty).ToList();
        }

        public void SaveOrUpdate(Especialista especialista)
        {
            var especialistaObj = _especialistaTable.Find(x => x.Id == especialista.Id).FirstOrDefault();
            if (especialistaObj == null)
            {
                _especialistaTable.InsertOne(especialista);
            }
            else
            {
                _especialistaTable.ReplaceOne(x => x.Id == especialistaObj.Id, especialista);
            }
        }
    }
}
