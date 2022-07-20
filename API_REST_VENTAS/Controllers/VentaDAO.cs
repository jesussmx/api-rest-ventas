using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_VENTAS.Controllers
{
    public class VentaDAO
    {
        private IConfiguration configuration;
        public VentaDAO(IConfiguration config)
        {
            configuration = config;
        }
        
        public bool eliminarProductoVenta(int idventaproducto, int idproducto, int cantidad)
        {
            var execute = SqlHelper.ExecuteDataset(configuration.GetConnectionString("conexion"), "eliminarProductoVenta", idventaproducto, idproducto, cantidad);
            return execute.HasErrors;
        }


        public bool crearVenta(int idcliente, int idempleado)
        {
            var execute = SqlHelper.ExecuteDataset(configuration.GetConnectionString("conexion"), "crearVenta", idcliente, idempleado);
            return execute.HasErrors;
        }

        public bool registrarProductosVenta(int idventa, int idproducto, decimal precioproducto, int cantidad)
        {
            var execute = SqlHelper.ExecuteDataset(configuration.GetConnectionString("conexion"), "registrarProductosVenta", idventa, idproducto, precioproducto, cantidad);
            return execute.HasErrors;
        }

        /*
        public bool buscarVentaPorId(int idventa)
        {
            var execute = SqlHelper.ExecuteDataset(configuration.GetConnectionString("conexion"), "buscarVentaPorId", idventa);
            return execute.HasErrors;
        }
        */

        public bool finalizarVenta(int idventa, int cantidaditem, decimal subtotal, decimal total)
        {
            var execute = SqlHelper.ExecuteDataset(configuration.GetConnectionString("conexion"), "finalizarVenta", idventa, cantidaditem, subtotal, total);
            return execute.HasErrors;
        }

        public bool generarMontoTotal(int idventa)
        {
            var execute = SqlHelper.ExecuteDataset(configuration.GetConnectionString("conexion"), "generarMontoTotal", idventa);
            return execute.HasErrors;
        }
    }
}
