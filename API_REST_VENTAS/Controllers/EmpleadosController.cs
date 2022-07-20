﻿using API_REST_VENTAS.Models;
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
    public class EmpleadosController : ControllerBase
    {
        private DB_PRENDASContext bd = new DB_PRENDASContext();
        private IConfiguration configuration;

        public EmpleadosController(IConfiguration config)
        {
            configuration = config;
        }

        // GET: api/<ControllerName>
        [HttpGet]
        public ActionResult Get()
        {
            var data = bd.Empleados.ToList();
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
            var data = bd.Empleados.Find(id);
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
        public ActionResult Post([FromBody] Empleados value)
        {
            if (value != null)
            {
                var val = bd.Empleados.Find(value);
                if (val != null)
                {
                    return BadRequest("Estos datos ya existen!"); ;
                }
                else
                {
                    bd.Empleados.Add(value);
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
        public ActionResult Put(int id, [FromBody] Empleados value)
        {
            if (value != null)
            {
                var val = bd.Empleados.Find(id);
                if (val != null)
                {
                    bd.Empleados.Update(value);
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
            var val = bd.Empleados.Find(id);
            if (val != null)
            {
                bd.Empleados.Remove(val);
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
