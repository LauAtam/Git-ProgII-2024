using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using WebAPI_prueba.Models;

namespace WebAPI_prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FechaController : ControllerBase
    {
        [HttpGet] //Ruta por defecto
        public IActionResult Get()
        {
            DateTime hoy = DateTime.Now;
            return Ok(new Fecha() {Dia=hoy.Day, DiaNombre=hoy.DayOfWeek.ToString(), Mes=hoy.Month, Año=hoy.Year});
            //numero, nombre del dia, mes y año
        }
    }
}
