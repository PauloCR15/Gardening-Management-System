using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba1.BLL;
using Models;
namespace Prueba1.Controllers
{
    [Route("api/Machinery")]
    [ApiController]
    public class MachineryController : ControllerBase
    {
        private readonly MachineryBLL _machineryBLL;
        public MachineryController(MachineryBLL machineryBLL)
        {
            _machineryBLL = machineryBLL;
        }

        [HttpGet]
        public ActionResult<List<Machinery>> Get()
        {
            try
            {
                var machinery = _machineryBLL.GetAllMachinery();
                if (machinery.Any())
                {
                    return machinery;
                }
                else
                {
                    return NotFound("Machinery Not Found");
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
                var machinery = _machineryBLL.GetMachineryByID(id);
                if (machinery == null)
                {
                    return NotFound("Machinery not found");
                }
                return Ok(machinery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Machinery machinery)
        {
            try
            {
                _machineryBLL.AddMachinery(machinery);
                return CreatedAtAction(nameof(Get), new { id = machinery.MachineryID }, machinery);
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
                _machineryBLL.RemoveMachineryByID(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("Edit/{id}")]
        public ActionResult Put(int id, Machinery machinery)
        {
            try
            {
                _machineryBLL.UpdateMachinery(id, machinery);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("GetLastMachineryID")]
        public ActionResult GetNextID()
        {
            try
            {
                var id = _machineryBLL.GetNextID();
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}