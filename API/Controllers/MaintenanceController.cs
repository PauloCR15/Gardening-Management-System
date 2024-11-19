using Microsoft.AspNetCore.Mvc;
using Models;
using Prueba1.BLL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba1.Controllers
{
    [Route("api/Maintenance")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly MaintenanceBLL _maintenanceBLL;
        public MaintenanceController(MaintenanceBLL maintenanceBLL)
        {
            _maintenanceBLL = maintenanceBLL;
        }
        [HttpGet]
        public ActionResult<List<Maintenance>> Get()
        {
            try
            {
                var maintenances = _maintenanceBLL.GetAllMaintenances();
                if (maintenances.Any())
                {
                    return maintenances;
                }
                else
                {
                    return NotFound("No maintenances found.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var maintenance = _maintenanceBLL.GetMaintenanceById(id);
                if (maintenance == null)
                {
                    return NotFound("Maintenance not found");
                }
                return Ok(maintenance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Maintenance maintenance)
        {
            try
            {
                _maintenanceBLL.AddMaintenance(maintenance);
                return Ok("Maintenance added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _maintenanceBLL.RemoveMaintenance(id);
                return Ok("Maintenance deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, Maintenance maintenance)
        {
            try
            {
                _maintenanceBLL.UpdateMaintenance(id,maintenance);
                return Ok("Maintenance updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("GetMaintenanceID")]
        public ActionResult GetNextID()
        {
            try
            {
                var nextID = _maintenanceBLL.GetNextId();
                return Ok(nextID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
