using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_REST_VENTAS.Models
{
    public partial class ProductosVenta
    {
        public int IdProductoVenta { get; set; }
        [Required]
        public int IdProducto { get; set; }
        [Required]
        public int IdVenta { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int Cantidad { get; set; }

        public virtual Productos IdProductoNavigation { get; set; }
        public virtual Ventas IdVentaNavigation { get; set; }
    }
}
