using agendamedica.Data;

namespace agendamedica.Iservice
{
    public interface IPacienteService
    {
        void SaveOrUpdate(Paciente paciente);
        Paciente GetPaciente(string pacienteId);
        List<Paciente> GetPacientes();
        string Delete(string pacienteId);
    }
}
