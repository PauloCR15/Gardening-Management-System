using static Tarea1.Models.Report;

namespace Tarea1.Services
{
    public interface IServicesReport
    {
        public Task<List<ProximosServiciosReport>> GetProximosServicios();
        public Task<List<ClientesSinServiciosReport>> GetClientesSinServicios();
    }
}
