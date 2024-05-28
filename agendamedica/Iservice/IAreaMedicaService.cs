using agendamedica.Data;

namespace agendamedica.Iservice
{
    public interface IAreaMedicaService
    {
        void SaveOrUpdate(AreaMedica areaMedica);
        AreaMedica GetAreaMedica(string areaMedicaId);
        List<AreaMedica> GetAreasMedicas();
        string Delete(string areaMedicaId);
    }
}
