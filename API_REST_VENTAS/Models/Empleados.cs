using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_REST_VENTAS.Models
{
    public partial class Empleados
    {
        public Empleados()
        {
            IngresosProducto = new HashSet<IngresosProducto>();
            Ventas = new HashSet<Ventas>();
        }

        public int IdEmpleado { get; set; }
        [Required]
        public string Cargo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }
        [Required]
        public string ApellidoMaterno { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Celular { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool Estado { get; set; }

        public virtual ICollection<IngresosProducto> IngresosProducto { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
