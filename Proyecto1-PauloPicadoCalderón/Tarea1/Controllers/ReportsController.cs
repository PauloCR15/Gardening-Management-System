using Microsoft.AspNetCore.Mvc;
using Tarea1.Services;
using static Tarea1.Models.Report;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tarea1.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IServicesReport _servicesReport;

        public ReportsController(IServicesReport servicesReport)
        {
            _servicesReport = servicesReport;
        }

        public async Task<ActionResult> List()
        {
            var proximosServicios = await _servicesReport.GetProximosServicios();
            var clientesSinServicios = await _servicesReport.GetClientesSinServicios();

            var reportesViewModel = new ReportesViewModel(proximosServicios, clientesSinServicios);

            return View(reportesViewModel);
        }
    }
}
