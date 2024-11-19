using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarea1.Models;
using Tarea1.Services;

namespace Tarea1.Controllers
{
    /// <summary>
    /// Controller for managing clients.
    /// </summary>
    public class ClientController : Controller
    {
        private readonly IServicesClient _iserviceClient;
        public ClientController(IServicesClient iserviceClient)
        {
            _iserviceClient = iserviceClient;
        }
        public async Task<ActionResult> List()
        {
            List<Client> clients;
            clients = await _iserviceClient.Get();
            return View(clients);
        }
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                Client client;
                client = await _iserviceClient.GetClientById(id);
                return View(client);
            }
            catch
            {
                TempData["ErrorMessage"] = "Cliente no encontrado.";
                return RedirectToAction("List");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Client client)
        {
            try
            {
                await _iserviceClient.Post(client);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                Client client;
                client = await _iserviceClient.GetClientById(id);
                return View(client);
            }
            catch
            {
                return RedirectToAction("List");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Client client)
        {
            bool edited = await _iserviceClient.UpdateClient(id, client);
            if (edited)
            {
                return RedirectToAction("List");
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Client client;
                client = await _iserviceClient.GetClientById(id);
                return View(client);
            }
            catch
            {
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _iserviceClient.DeleteClient(id);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }

        }


    }

}
