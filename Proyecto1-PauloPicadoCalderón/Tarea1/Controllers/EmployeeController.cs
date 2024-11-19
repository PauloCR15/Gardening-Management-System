using Microsoft.AspNetCore.Mvc;
using Tarea1.Models;
using Tarea1.Services;

namespace Tarea1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IServicesEmployee _iservicesEmployee;

        public EmployeeController(IServicesEmployee servicesEmployee)
        {
            _iservicesEmployee = servicesEmployee;
        }

        public async Task<ActionResult> List()
        {
            List<Employee> employees;
            employees = await _iservicesEmployee.Get();
            return View(employees);
        }

        public async Task<ActionResult> Details(int id)
        {
            try
            {


                Employee employee;
                employee = await _iservicesEmployee.GetEmployeeById(id);
                return View(employee);
            }
            catch
            {
                TempData["ErrorMessage"] = "Empleado no encontrado.";
                return RedirectToAction(nameof(List));
            }
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Employee employee)
        {
            try
            {
                await _iservicesEmployee.Post(employee);
                return RedirectToAction(nameof(List));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            Employee employee;
            employee = await _iservicesEmployee.GetEmployeeById(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Employee employee)
        {
            bool edited = await _iservicesEmployee.UpdateEmployee(id, employee);
            if (edited)
            {
                return RedirectToAction(nameof(List));
            }
            return View();

        }

        public async Task<ActionResult> Delete(int id)
        {
            Employee employee;
            try
            {
                employee = await _iservicesEmployee.GetEmployeeById(id);
                return View(employee);
            }
            catch
            {
                return RedirectToAction(nameof(List));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            bool deleted = await _iservicesEmployee.DeleteEmployee(id);
            if (deleted)
            {
                return RedirectToAction(nameof(List));
            }
            return View();
        }
    }
}
