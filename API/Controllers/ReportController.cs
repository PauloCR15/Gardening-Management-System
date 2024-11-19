using Microsoft.AspNetCore.Mvc;
using Prueba1.BLL;


namespace API_Proyecto_2.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportController(MaintenanceBLL maintenanceBLL, ClientBLL clientBLL)
        {
            _reportService = new ReportService(maintenanceBLL, clientBLL);
        }

        [HttpGet("ProximosServicios")]
        public ActionResult<IEnumerable<ProximosServiciosReport>> GetProximosServicios()
        {
            var reports = _reportService.GetProximosServicios();
            return Ok(reports);
        }

        [HttpGet("ClientesSinServicios")]
        public ActionResult<IEnumerable<ClientesSinServiciosReport>> GetClientesSinServicios()
        {
            var reports = _reportService.GetClientesSinServicios();
            return Ok(reports);
        }
    }
}
