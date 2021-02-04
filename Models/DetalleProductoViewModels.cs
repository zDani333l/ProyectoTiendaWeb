using ProyectoWebAppTienda.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWebAppTienda.Models
{
    public class DetalleProductoViewModels
    {
		public int ProductoId { get; set; }
		public string NombreProducto { get; set; }
		public string Descripcion { get; set; }
		public double Precio { get; set; }
		public int Cantidad { get; set; }
		public string Talla { get; set; }
		public string Color { get; set; }
		public string Categoria { get; set; }
		public List<Tbl_imagen> Imagenes { get; set; }
		public List<Tbl_Producto> ProductosRelacionados { get; set; } 

	}
}