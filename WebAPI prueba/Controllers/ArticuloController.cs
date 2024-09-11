using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebAPI_prueba.Models;

namespace WebAPI_prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok(new Articulo() { Id=1, Nombre="Lapicera", Precio=500.50f});
        }
    }
}
