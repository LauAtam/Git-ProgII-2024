using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_prueba.Models;

namespace WebAPI_prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashController : ControllerBase
    {
        private static List<Moneda> Monedas = new List<Moneda>();
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Monedas);
        }
        [HttpGet("Monedas")]
        public IActionResult GetMonedas([FromQuery]string nombre)
        {
            foreach (var moneda in Monedas)
            {
                if (moneda.Nombre == nombre)
                {
                    return Ok(moneda);
                }
            }
            return NotFound($"Moneda {nombre} no encontrada en la lista de monedas");
        }
        [HttpGet("buscar")]
        public IActionResult GetSlash(string nombre)
        {
            foreach (var moneda in Monedas)
            {
                if (moneda.Nombre == nombre)
                {
                    return Ok(moneda);
                }
            }
            return NotFound($"Moneda {nombre} no encontrada en la lista de monedas");
        }
        [HttpPost]
        public IActionResult Post([FromBody] Moneda moneda)
        {
            if (moneda == null || string.IsNullOrEmpty(moneda.Nombre))
                return BadRequest("Datos no validos");
            Monedas.Add(moneda);
            return Ok($"{moneda.Nombre} con valor ${moneda.ValorEnPesos} agregada a la lista de monedas");
        }

    }
}
