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

        public ActionResult ListaProductos(int pagina = 1, int _RegistrosPorPagina = 3)
        {

            PaginadorGenerico<DetalleProductoViewModel> _PaginadorProductos;

            // Almacenar la consulta de la tabla (objeto) 
            List<DetalleProductoViewModel> _productos = this.xd();

            // Número total de registros de la tabla 
            int _TotalRegistros = _productos.Count;

            // Número total de páginas de la tabla
            var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);

            _PaginadorProductos = new PaginadorGenerico<DetalleProductoViewModel> {
                RegistrosPorPagina = _RegistrosPorPagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                Resultado = _productos
                
            };

            return View(_PaginadorProductos);
        }

        public List<DetalleProductoViewModel> xd()
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
                Img2 = Path.Combine(Server.MapPath("~/imgP/"), "2.jpg"),
                Img3 = Path.Combine(Server.MapPath("~/imgP/"), "3.jpg"),
                Precio = 280.000,
                Descripcion = "Esta es la descripcion de nuestro producto que esta 10/10 mi perrito :v"

            };
            DetalleProductoViewModel m1 = new DetalleProductoViewModel
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
                Img2 = Path.Combine(Server.MapPath("~/imgP/"), "2.jpg"),
                Img3 = Path.Combine(Server.MapPath("~/imgP/"), "3.jpg"),
                Precio = 280.000,
                Descripcion = "Esta es la descripcion de nuestro producto que esta 10/10 mi perrito :v"

            };
            DetalleProductoViewModel m2 = new DetalleProductoViewModel
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
                Img2 = Path.Combine(Server.MapPath("~/imgP/"), "2.jpg"),
                Img3 = Path.Combine(Server.MapPath("~/imgP/"), "3.jpg"),
                Precio = 280.000,
                Descripcion = "Esta es la descripcion de nuestro producto que esta 10/10 mi perrito :v"

            };
            DetalleProductoViewModel m3 = new DetalleProductoViewModel
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
                Img2 = Path.Combine(Server.MapPath("~/imgP/"), "2.jpg"),
                Img3 = Path.Combine(Server.MapPath("~/imgP/"), "3.jpg"),
                Precio = 280.000,
                Descripcion = "Esta es la descripcion de nuestro producto que esta 10/10 mi perrito :v"

            };
            DetalleProductoViewModel m4 = new DetalleProductoViewModel
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
                Img2 = Path.Combine(Server.MapPath("~/imgP/"), "2.jpg"),
                Img3 = Path.Combine(Server.MapPath("~/imgP/"), "3.jpg"),
                Precio = 280.000,
                Descripcion = "Esta es la descripcion de nuestro producto que esta 10/10 mi perrito :v"

            };

            DetalleProductoViewModel m5 = new DetalleProductoViewModel
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
                Img2 = Path.Combine(Server.MapPath("~/imgP/"), "2.jpg"),
                Img3 = Path.Combine(Server.MapPath("~/imgP/"), "3.jpg"),
                Precio = 280.000,
                Descripcion = "Esta es la descripcion de nuestro producto que esta 10/10 mi perrito :v"

            };
            DetalleProductoViewModel m6 = new DetalleProductoViewModel
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
                Img2 = Path.Combine(Server.MapPath("~/imgP/"), "2.jpg"),
                Img3 = Path.Combine(Server.MapPath("~/imgP/"), "3.jpg"),
                Precio = 280.000,
                Descripcion = "Esta es la descripcion de nuestro producto que esta 10/10 mi perrito :v"

            };
            List<DetalleProductoViewModel> pro;
            pro = new List<DetalleProductoViewModel> { };
            pro.Add(m);
            pro.Add(m1);
            pro.Add(m2);
            pro.Add(m3);
            pro.Add(m4);
            pro.Add(m5);
            pro.Add(m6);
            return pro;
        }
    }
}
