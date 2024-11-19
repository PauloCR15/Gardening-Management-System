using Tarea1.Models;
namespace Tarea1.Models
{
    public class Report
    {
        public class ReportesViewModel
        {
            public List<ProximosServiciosReport> ProximosServicios { get; set; }
            public List<ClientesSinServiciosReport> ClientesSinServicios { get; set; }

            public ReportesViewModel(List<ProximosServiciosReport> proximosServicios, List<ClientesSinServiciosReport> clientesSinServicios)
            {
                ProximosServicios = proximosServicios;
                ClientesSinServicios = clientesSinServicios;
            }
        }

        public class ProximosServiciosReport
        {
            public string ClientName { get; set; }
            public DateTime ScheduledDate { get; set; }
            public string Address { get; set; }
            public string Status { get; set; }
        }

        public class ClientesSinServiciosReport
        {
            public string ClientName { get; set; }
            public DateTime LastMaintenanceDate { get; set; }
            public string Address { get; set; }
        }
    }
}
