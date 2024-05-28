using agendamedica.Data;
using agendamedica.Iservice;
using MongoDB.Driver;

namespace agendamedica.Service
{
    public class AreaMedicaService : IAreaMedicaService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<AreaMedica> _areaMedicaTable = null;
        public AreaMedicaService()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017/");
            _database = _mongoClient.GetDatabase("CLinica");
            _areaMedicaTable = _database.GetCollection<AreaMedica>("AreaMedica");
        }
        public string Delete(string areaMedicaId)
        {
            _areaMedicaTable.DeleteOne(x => x.Id == areaMedicaId);
            return "Deleted";
        }

        public AreaMedica GetAreaMedica(string areaMedicaId)
        {
            return _areaMedicaTable.Find(x => x.Id == areaMedicaId).FirstOrDefault();
        }

        public List<AreaMedica> GetAreasMedicas()
        {
            return _areaMedicaTable.Find(FilterDefinition<AreaMedica>.Empty).ToList();
        }

        public void SaveOrUpdate(AreaMedica areaMedica)
        {
            var areaMedicaObj = _areaMedicaTable.Find(x => x.Id == areaMedica.Id).FirstOrDefault();
            if (areaMedicaObj == null) 
            {
                _areaMedicaTable.InsertOne(areaMedica);
            }
            else 
            {
                _areaMedicaTable.ReplaceOne(x => x.Id == areaMedicaObj.Id, areaMedica);
            }
        }
    }
}
