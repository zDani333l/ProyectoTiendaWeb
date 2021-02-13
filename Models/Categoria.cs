using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWebAppTienda.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "Se requiere nombre de categoria")]
        [StringLength(100, ErrorMessage = "Minimo 3 y minimo 5 y maximo 100 char", MinimumLength = 3)]
        public string NombreCategoria { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }

    public class Producto
    {
        public int ProductoId { get; set; }
        [Required(ErrorMessage = "Se requiere nombre de producto")]
        [StringLength(100, ErrorMessage = "Minimo 3 y minimo 5 y maximo 100 char", MinimumLength = 3)]
        public string NombreProducto { get; set; }
        [Required]
        [Range(1, 50)]
        public Nullable<int> CategoriaId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        [Required(ErrorMessage = "Se requiere una descripcion")]
        public string Descripcion { get; set; }
        public Nullable<int> IdImagen { get; set; }
        [Required(ErrorMessage = "Se requiere nombre de categoria")]
        [Range(typeof(int), "1", "500", ErrorMessage = "cantidad invalida")]
        public Nullable<int> Cantidad { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> ProveedorId { get; set; }
        [Required]
        [Range(typeof(decimal), "1", "90000000", ErrorMessage = "precio invalido")]
        public Nullable<decimal> Precio { get; set; }
        public SelectList Categorias { get; set; }
    }
}
