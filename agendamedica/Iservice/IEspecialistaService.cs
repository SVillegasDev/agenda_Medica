using agendamedica.Data;

namespace agendamedica.Iservice
{
    public interface IEspecialistaService
    {
        void SaveOrUpdate(Especialista especialista);
        Especialista GetEspecialista(string especialistaId);
        List<Especialista> GetEspecialista();
        string Delete(string especialistaId);
    }
}