using agendamedica.Data;

namespace agendamedica.Iservice
{
    public interface IAppointmentService
    {
        void SaverOrUpdate(Appointment appointment);
        Appointment GetAppointment(string appointmentId);
        List<Appointment> GetAppointment();
        string Delete(string appointmentId);
    }
}

