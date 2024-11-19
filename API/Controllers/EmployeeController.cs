using Microsoft.AspNetCore.Mvc;
using Prueba1.BLL;
using Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba1.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeBLL _employeeBLL;
        public EmployeeController(EmployeeBLL employeeBLL)
        {
            _employeeBLL = employeeBLL;

        }
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            try
            {
                var employees = _employeeBLL.GetAllEmployees();
                if (employees.Any())
                {
                    return employees;
                }
                else
                {
                    return NotFound("No employees found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("GetByID/{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var employee = _employeeBLL.GetEmployeeByID(id);
                if (employee == null)
                {
                    return NotFound("Employee Not Found");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Employee employee)
        {
            try
            {
                _employeeBLL.Add(employee);
                return CreatedAtAction(nameof(Get), new { id = employee.EmployeeID }, employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _employeeBLL.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("Edit/{id}")]
        public ActionResult Put(int id, Employee employee)
        {
            try
            {
                _employeeBLL.UpdateClient(id, employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}

