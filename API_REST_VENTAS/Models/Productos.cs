using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_REST_VENTAS.Models
{
    public partial class Productos
    {
        public Productos()
        {
            IngresosProducto = new HashSet<IngresosProducto>();
            ProductosVenta = new HashSet<ProductosVenta>();
        }

        public int IdProducto { get; set; }
        [Required]
        public int IdCategoria { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public bool Estado { get; set; }
        [Required]
        public string Talla { get; set; }

        public virtual Categorias IdCategoriaNavigation { get; set; }
        public virtual ICollection<IngresosProducto> IngresosProducto { get; set; }
        public virtual ICollection<ProductosVenta> ProductosVenta { get; set; }
    }
}
