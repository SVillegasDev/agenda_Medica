using agendamedica.Data;
using agendamedica.Iservice;
using agendamedica.Service;
using MongoDB.Driver;

namespace agendamedica.Service
{
    public class AppointmentService : IAppointmentService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Appointment> _appointmentTable = null;
        public AppointmentService()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017/");
            _database = _mongoClient.GetDatabase("CLinica");
            _appointmentTable = _database.GetCollection<Appointment>("Appointment");
        }
        public string Delete(string appointmentId)
        {
            _appointmentTable.DeleteOne(x => x.Id == appointmentId);
            return "Deleted";
        }

        public Appointment GetAppointment(string appointmentId)
        {
            return _appointmentTable.Find(x => x.Id == appointmentId).FirstOrDefault();
        }

        public List<Appointment> GetAppointment()
        {
            return _appointmentTable.Find(FilterDefinition<Appointment>.Empty).ToList();
        }

        public void SaverOrUpdate(Appointment appointment)
        {
            var appointmentObj = _appointmentTable.Find(x => x.Id == appointment.Id).FirstOrDefault();
            if (appointmentObj == null) {
                _appointmentTable.InsertOne(appointment);
            }
            else {
                _appointmentTable.ReplaceOne(x => x.Id == appointmentObj.Id, appointment);
            }
        }
    }
}

