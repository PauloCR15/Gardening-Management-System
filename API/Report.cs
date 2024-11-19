// Clase base para manejar reportes
using Models;
using Prueba1.BLL;
using Prueba1.DAL;

public class ReportService
{
    private List<Maintenance> _maintenances;
    private List<Client> _clients;
    private readonly MaintenanceBLL _maintenanceBLL;
    private readonly ClientBLL _clientBLL;

    public ReportService(MaintenanceBLL maintenanceBLL, ClientBLL clientBLL)
    {
        _maintenanceBLL = maintenanceBLL;
        _clientBLL = clientBLL;
        _maintenances = maintenanceBLL.GetAllMaintenances(); // Obtener mantenimientos
        _clients = _clientBLL.GetAllClients(); // Obtener clientes
    }

    // Método para obtener los reportes de próximos servicios
    public List<ProximosServiciosReport> GetProximosServicios()
    {
        return _maintenances
            .Where(m => m.MaintenanceScheduledDate >= DateTime.Now && m.MaintenanceScheduledDate < DateTime.Now.AddDays(7))
            .Select(m => new ProximosServiciosReport
            {
                ClientName = _clients.FirstOrDefault(c => c.ClientID == m.ClientID)?.ClientFullName ?? string.Empty,
                ScheduledDate = m.MaintenanceScheduledDate,
                Address = _clients.FirstOrDefault(c => c.ClientID == m.ClientID)?.ClientFullDirection ?? string.Empty,
                Status = m.MaintenanceStatus.ToString(),
            }).ToList();
    }

    // Método para obtener los reportes de clientes sin servicios
    public List<ClientesSinServiciosReport> GetClientesSinServicios()
    {
        return _clients
            .Where(c =>
                // Verifica que no tenga mantenimientos en los últimos 2 meses
                !_maintenances.Any(m => m.ClientID == c.ClientID && m.MaintenanceExecutedDate > DateTime.Now.AddMonths(-2)) &&
                // Asegúrate de que el cliente tiene al menos un mantenimiento registrado
                _maintenances.Any(m => m.ClientID == c.ClientID))
            .Select(c => new ClientesSinServiciosReport
            {
                ClientName = c.ClientFullName,
                LastMaintenanceDate = _maintenances
                    .Where(m => m.ClientID == c.ClientID)
                    .OrderByDescending(m => m.MaintenanceExecutedDate)
                    .Select(m => m.MaintenanceExecutedDate)
                    .FirstOrDefault(),
                Address = c.ClientFullDirection
            }).ToList();
    }
}

// Modelos para el reporte
public class ProximosServiciosReport
{
    public required string ClientName { get; set; }
    public DateTime ScheduledDate { get; set; }
    public required string Address { get; set; }
    public required string Status { get; set; }
}

public class ClientesSinServiciosReport
{
    public required string ClientName { get; set; }
    public DateTime LastMaintenanceDate { get; set; }
    public required string Address { get; set; }
}
