using Microsoft.AspNetCore.Mvc;
using Tarea1.Models;
using Tarea1.Services;

namespace Tarea1.Controllers
{
    /// <summary>
    /// Controller for managing maintenance operations.
    /// </summary>
    public class MaintenanceController : Controller
    {
        private readonly IServicesMaintenance _servicesMaintenance;

        public MaintenanceController(IServicesMaintenance servicesMaintenance)
        {
            _servicesMaintenance = servicesMaintenance;
        }

        public async Task<ActionResult> List()
        {
            List<Maintenance> maintenances;
            maintenances = await _servicesMaintenance.Get();
            return View(maintenances);
        }

        public async Task<ActionResult> Details(int id)
        {
            try{
                Maintenance maintenance;
                maintenance = await _servicesMaintenance.Get(id);
                return View(maintenance);
            }
            catch
            {
                TempData["ErrorMessage"] = "Maintenance not found.";
                return RedirectToAction("List");
            }
        }


        public async Task<ActionResult> CreateMaintenance()
        {
            int id;
            id = await _servicesMaintenance.GetID();
            ViewData["ClientID"] = id;
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateMaintenance(Maintenance newMaintenance)
        {
            try
            {
                Console.WriteLine($"TotalCost: {newMaintenance}");
                await _servicesMaintenance.Post(newMaintenance);
                    return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                var errors = ex.Message.Split('\n');
                foreach (var error in errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
                int id;
                id = await _servicesMaintenance.GetID();
                ViewData["ClientID"] = id;
                return View(newMaintenance);
            }
        }




        public async Task<ActionResult> Edit(int id)
        {
            Maintenance maintenance;
            maintenance = await _servicesMaintenance.Get(id);
            return View(maintenance);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Maintenance maintenance)
        {
            try
            {
                await _servicesMaintenance.Edit(id, maintenance);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }

        }


        public async Task<ActionResult> Delete(int id)
        {
            Maintenance maintenance;
            maintenance = await _servicesMaintenance.Get(id);
            return View(maintenance);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _servicesMaintenance.Delete(id);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }

        }
    }
}
