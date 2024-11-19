
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Prueba1.BLL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba1.Controllers
{
   
    [Route("api/Client")]
    [EnableCors("_myAllowSpecificOrigins")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientBLL _clientBLL;
        public ClientController(ClientBLL clientBLL)
        {
            _clientBLL = clientBLL;
        }

        [HttpGet]
        public ActionResult<List<Client>> Get()
        {
            try
            {
                var clients = _clientBLL.GetAllClients();
                if (clients.Any())
                {
                    return clients;
                }
                else
                {
                    return NotFound("No clients found.");
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
                var client = _clientBLL.GetClientById(id);
                if (client == null)
                {
                    return NotFound("Client not found");
                }
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Client client)
        {
            try
            {
                _clientBLL.AddClient(client);
                return CreatedAtAction(nameof(Get), new { id = client.ClientID }, client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _clientBLL.RemoveClient(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut("Edit/{id}")]

        public ActionResult Put(int id, [FromBody] Client client)
        {
            try
            {
                _clientBLL.UptadeClient(id, client);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("CheckID/{id}")]
        public ActionResult<bool> checkID(int id)
        {
            try
            {
                bool isValidUser = _clientBLL.checkID(id);
                return Ok(isValidUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
