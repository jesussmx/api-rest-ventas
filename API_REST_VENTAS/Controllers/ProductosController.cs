using API_REST_VENTAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_REST_VENTAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private DB_PRENDASContext bd = new DB_PRENDASContext();
        private IConfiguration configuration;

        public ProductosController(IConfiguration config)
        {
            configuration = config;
        }

        // GET: api/<ControllerName>
        [HttpGet]
        public ActionResult Get()
        {
            var data = bd.Productos.ToList();
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
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var data = bd.Productos.Find(id);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("No hay datos para mostrar");
            }
        }

        // POST api/<ControllerName>
        [HttpPost]
        public ActionResult Post([FromBody] IngresosProducto value)
        {
            if (value != null)
            {
                var val = bd.Productos.Find(value);
                if (val != null)
                {
                    return BadRequest("Estos datos ya existen!"); ;
                }
                else
                {
                    bd.IngresosProducto.Add(value);
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
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Productos value)
        {
            if (value != null)
            {
                var val = bd.Productos.Find(id);
                if (val != null)
                {
                    bd.Productos.Update(value);
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
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var val = bd.Productos.Find(id);
            if (val != null)
            {
                bd.Productos.Remove(val);
                bd.SaveChanges();
                return Ok("Eliminado!");
            }
            else
            {
                return BadRequest("No se ha podido eliminar porque no existe!");
            }

        }


        /*
        [HttpGet("categoria/{id}")]
        public ProductoCategoria GET(int id)
        {
            var sql = SqlHelper.ExecuteReader(configuration.GetConnectionString("conexion"), "TEST_PRODUCTO_CATEGORIA", id);
            ProductoCategoria producto = null;
            while (sql.Read())
            {
                producto = new ProductoCategoria
                {
                    id_categoria = sql.GetInt32(0),
                    nombre = sql.GetString(1),
                    descripcion = sql.GetString(2),
                    stock = sql.GetInt32(3),
                    precio = sql.GetDecimal(4),
                    categoria = sql.GetString(5)
                };
                
            }

            return producto;
        }
        */
    }
}
