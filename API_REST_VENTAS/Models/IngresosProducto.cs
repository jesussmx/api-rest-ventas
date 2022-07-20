using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_REST_VENTAS.Models
{
    public partial class IngresosProducto
    {
        public int IdIngreso { get; set; }
        [Required]
        public int IdProducto { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        [Required]
        public string Proveedor { get; set; }
        [Required]
        public string NroGuia { get; set; }
        public int? IdEmpleado { get; set; }

        public virtual Empleados IdEmpleadoNavigation { get; set; }
        public virtual Productos IdProductoNavigation { get; set; }
    }
}
