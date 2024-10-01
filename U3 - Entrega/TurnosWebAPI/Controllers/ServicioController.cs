using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TurnosWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private IServicioRepository _repository;
        public ServicioController(IServicioRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<ServicioController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "ERROR HUMANO");
            }
        }

        // POST api/<ServicioController>
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return null;
        }

        // GET api/<ServicioController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // PUT api/<ServicioController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<ServicioController>/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
