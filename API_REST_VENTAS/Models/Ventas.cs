using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_REST_VENTAS.Models
{
    public partial class Ventas
    {
        public Ventas()
        {
            ProductosVenta = new HashSet<ProductosVenta>();
        }

        public int IdVenta { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public int IdEmpleado { get; set; }
        [Required]
        public DateTime FehaRegistro { get; set; }
        [Required]
        public decimal CantidadTotal { get; set; }
        [Required]
        public decimal SubTotal { get; set; }
        [Required]
        public int Igv { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public bool Estado { get; set; }

        public virtual Clientes IdClienteNavigation { get; set; }
        public virtual Empleados IdEmpleadoNavigation { get; set; }
        public virtual ICollection<ProductosVenta> ProductosVenta { get; set; }
    }
}
