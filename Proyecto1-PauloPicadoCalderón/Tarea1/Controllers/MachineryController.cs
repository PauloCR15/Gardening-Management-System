using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarea1.Models;
using Tarea1.Services;
namespace Tarea1.Controllers
{
    /// <summary>
    /// Controller for managing machinery.
    /// </summary>
    public class MachineryController : Controller
    {
        private readonly IServicesMachinery _serviceMachinery;
        public MachineryController(IServicesMachinery iserviceMachinery)
        {
            _serviceMachinery = iserviceMachinery;
        }
        /// <summary>
        /// List of machinery.
        /// </summary>


        /// <summary>
        /// Displays the list of machinery.
        /// </summary>
        /// <returns>The view containing the list of machinery.</returns>
        public async Task<ActionResult> List()
        {
            List<Machinery> machineries;
            machineries = await _serviceMachinery.Get();
            return View(machineries);
        }

        /// <summary>
        /// Displays the details of a specific machinery.
        /// </summary>
        /// <param name="id">The ClientID of the machinery.</param>
        /// <returns>The view containing the details of the machinery.</returns>
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                Machinery machinery;
                machinery = await _serviceMachinery.GetMachineryByID(id);
                return View(machinery);
            }
            catch
            {
                TempData["ErrorMessage"] = "Maquinaria no encontrada";
                return RedirectToAction("List");
            }
        }

        /// <summary>
        /// Displays the form for creating a new machinery.
        /// </summary>
        /// <returns>The view containing the form for creating a new machinery.</returns>
        public async Task<ActionResult> Create()
        {

            var lastId = await _serviceMachinery.GetLastMachineryID();
            ViewData["ClientID"] = lastId;
            return View();
        }

        /// <summary>
        /// Creates a new machinery.
        /// </summary>
        /// <param name="NewMachine">The new machinery to create.</param>
        /// <returns>Redirects to the list of machinery if the creation is successful, otherwise returns the create view.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Machinery NewMachine)
        {
            try
            {
                await _serviceMachinery.Post(NewMachine);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        /// <summary>
        /// Displays the form for editing a machinery.
        /// </summary>
        /// <param name="id">The ClientID of the machinery to edit.</param>
        /// <returns>The view containing the form for editing the machinery.</returns>
        public async Task<ActionResult> Edit(int id)
        {
            var Machine = await _serviceMachinery.GetMachineryByID(id);
            if (Machine == null)
            {
                return NotFound();
            }
            else
            {
                return View(Machine);
            }
        }

        /// <summary>
        /// Edits a machinery.
        /// </summary>
        /// <param name="id">The ClientID of the machinery to edit.</param>
        /// <param name="collection">The form collection containing the updated machinery data.</param>
        /// <returns>Redirects to the list of machinery if the edit is successful, otherwise returns the edit view.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Machinery machinery)
        {
            bool edited = await _serviceMachinery.UpdateMachinery(id, machinery);
            if (edited)
            {
                return RedirectToAction("List");
            }
            return View();
        }

        /// <summary>
        /// Displays the confirmation dialog for deleting a machinery.
        /// </summary>
        /// <param name="id">The ClientID of the machinery to delete.</param>
        /// <returns>The view containing the confirmation dialog for deleting the machinery.</returns>
        public async Task<ActionResult> Delete(int id)
        {
            var Machine = await _serviceMachinery.GetMachineryByID(id);
            return View(Machine);
        }

        /// <summary>
        /// Deletes a machinery.
        /// </summary>
        /// <param name="id">The ClientID of the machinery to delete.</param>
        /// <param name="collection">The form collection.</param>
        /// <returns>Redirects to the list of machinery.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _serviceMachinery.DeleteMachinery(id);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
