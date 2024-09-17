using Microsoft.AspNetCore.Mvc;
using FacturacionBack.Servicios;
using FacturacionBack.Modelos;

namespace ArticulosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private ArticuloManager _manager;
        public ArticulosController()
        {
            _manager = new ArticuloManager();
        }
        [HttpGet("GetArticulos")]
        public IActionResult GetArticulos()
        {
            return Ok(_manager.ObtenerArticulos());
        }
        [HttpPost("PostArticulos")]
        public IActionResult PostArticulos([FromBody] Articulo articulo)
        {
            try
            {
                if (articulo == null)
                {
                    return BadRequest("No se puede agregar un articulo vacio");
                }
                if (_manager.RegistrarArticulo(articulo))
                {
                    return Created();
                }
                else
                {
                    return StatusCode(500, "No se pudo agregar el articulo");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("DeleteArticulos")]
        public IActionResult DeleteArticulos([FromBody] Articulo articulo)
        {
            if (_manager.EliminarArticulo(articulo))
            {
                return Accepted($"El articulo con id {articulo.Id} se ha eliminado correctamente");
            }
            else
            {
                return BadRequest($"No se ha eliminado el articulo con id {articulo.Id}");
            }
        }
    }
}
