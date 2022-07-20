using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_REST_VENTAS.Controllers
{
    [Route("api/ventas/procedimientos/")]
    [ApiController]
    public class VentasDAOController : ControllerBase
    {

        private IConfiguration configuration;
        private VentaDAO ventadao;

        public VentasDAOController(IConfiguration config)
        {
            configuration = config;
            ventadao = new VentaDAO(config);
        }

        //

        public class eliminarproductoventamodel
        {
            public int idventaproducto { get; set; }
            public int idproducto { get; set; }
            public int cantidad { get; set; }
        }

        public class crearventamodel
        {
            public int idcliente { get; set; }
            public int idempleado { get; set; }
        }

        public class registrarproductosventamodel
        {
            public int idventa { get; set; }
            public int idproducto { get; set; }
            public decimal precioproducto { get; set; }
            public int cantidad { get; set; }
        }

        public class finalizarventamodel
        {
            public int idventa { get; set; }
            public int cantidaditem { get; set; }
            public decimal subtotal { get; set; }
            public int total { get; set; }
        }

        public class generarmontototalmodel
        {
            public int idventa { get; set; }
        }

        [HttpPost("eliminarProductoVenta")]
        public ActionResult eliminarProductoVenta([FromBody] eliminarproductoventamodel value)
        {
            var execute = ventadao.eliminarProductoVenta(value.idventaproducto, value.idproducto, value.cantidad);

            if (execute == false)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpPost("registrarProductosVenta")]
        public ActionResult registrarProductosVenta([FromBody] registrarproductosventamodel value)
        {
            var execute = ventadao.registrarProductosVenta(value.idventa, value.idproducto, value.precioproducto, value.cantidad);

            if (execute == false)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpPost("crearVenta")]
        public ActionResult crearVenta([FromBody] crearventamodel value)
        {
            var execute = ventadao.crearVenta(value.idcliente, value.idempleado);

            if (execute == false)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpPost("finalizarVenta")]
        public ActionResult finalizarVenta([FromBody] finalizarventamodel value)
        {
            var execute = ventadao.finalizarVenta(value.idventa, value.cantidaditem, value.subtotal, value.total);

            if (execute == false)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpPost("generarMontoTotal")]
        public ActionResult generarMontoTotal([FromBody] generarmontototalmodel value)
        {
            var execute = ventadao.generarMontoTotal(value.idventa);

            if (execute == false)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }
    }
}
