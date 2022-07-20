using API_REST_VENTAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_REST_VENTAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private DB_PRENDASContext bd = new DB_PRENDASContext();
        private IConfiguration configuration;

        public VentasController(IConfiguration config)
        {
            configuration = config;
        }
        // GET: api/<ControllerName>
        [HttpGet("listarVentas")]
        public ActionResult Get()
        {
            var data = bd.Ventas.ToList();
            if (data.Count() > 0)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("No hay datos para mostrar");
            }
        }

        // GET api/<ControllerName>/5
        [HttpGet("consultarVentaPorId/{id}")]
        public ActionResult Get(int id)
        {
            var data = bd.Ventas.Find(id);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("No hay datos para mostrar");
            }
        }

        // GET api/<ControllerName>/5
        [HttpGet("consultarVentaPorFecha/{fecha}")]
        public Ventas Get2(string fecha)
        {
            var data = bd.Ventas.Where(w => w.FehaRegistro.ToString("yyyy-MM-dd") == fecha).First();
            return data;
        }

        // POST api/<ControllerName>
        [HttpPost("registrarVenta")]
        public ActionResult Post([FromBody] Ventas value)
        {
            if (value != null)
            {
                var val = bd.Ventas.Find(value);
                if (val != null)
                {
                    return BadRequest("Estos datos ya existen!"); ;
                }
                else
                {
                    bd.Ventas.Add(value);
                    bd.SaveChanges();
                    return Ok("Añadido!");

                }

            }
            else
            {
                return NotFound("No hay datos para mostrar");
            }

        }

        // PUT api/<ControllerName>/5
        [HttpPut("actualizarVentaPorId/{id}")]
        public ActionResult Put(int id, [FromBody] Ventas value)
        {
            if (value != null)
            {
                var val = bd.Ventas.Find(id);
                if (val != null)
                {
                    bd.Ventas.Update(value);
                    bd.SaveChanges();
                    return Ok("Editado!");
                }
                else
                {
                    return BadRequest("No se ha podido editar porque no existe!");
                }

            }
            else
            {
                return BadRequest("Los datos que ha enviado estan incompletos!");
            }
        }

        // DELETE api/<ControllerName>/5
        [HttpDelete("eliminarVentaPorId/{id}")]
        public ActionResult Delete(int id)
        {
            var val = bd.Ventas.Find(id);
            if (val != null)
            {
                bd.Ventas.Remove(val);
                bd.SaveChanges();
                return Ok("Eliminado!");
            }
            else
            {
                return BadRequest("No se ha podido eliminar porque no existe!");
            }

        }

    }
}
