using ProyectoWebAppTienda.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWebAppTienda.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult DetalleProducto()
        {
            DetalleProductoViewModel m = new DetalleProductoViewModel
            {
                
                NombrePrudcto = "Bicicleta Tipo Fixie - Innova",
                Tallas = new String[]
                {
                    "S","M","L"
                },
                Categorias = new String[]
                {
                    "Urbano","Fixie","Acero"
                },
                Img1 = Path.Combine(Server.MapPath("~/imgP/"), "1.jpg"),
                Img2= Path.Combine(Server.MapPath("~/imgP/"), "2.jpg"),
                Img3 = Path.Combine(Server.MapPath("~/imgP/"), "3.jpg"),
                Precio = 280.000,
                Descripcion="Esta es la descripcion de nuestro producto que esta 10/10 mi perrito :v"

            };
            
            return View(m);
        }

        public ActionResult ListaProductos()
        {
            return View();
        }

        
    }
}