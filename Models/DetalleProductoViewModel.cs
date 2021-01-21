using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWebAppTienda.Models
{
    public class DetalleProductoViewModel
    {
        public String NombrePrudcto { get; set; }
        public String Img1 { get; set; }
        public String Img2 { get; set; }
        public String Img3 { get; set; }
        public double Precio { get; set; }
        public string[] Tallas { get; set; }
        public string Descripcion { get; set; }
        public string[] Categorias { get; set; }



    }
}