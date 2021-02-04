using ProyectoWebAppTienda.DAL;
using ProyectoWebAppTienda.Models;
using ProyectoWebAppTienda.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace ProyectoWebAppTienda.Controllers
{
    public class ProductoController : Controller
    {
        private GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public ActionResult DetalleProducto(int id, string buscar, int pagina = 1, int check=0)
        {
            ViewBag.buscar = buscar;
            ViewBag.pag = pagina;
            ViewBag.check = check;

            //CONSULTAS A LA BASE DE DATOS
            var auxProducto = _unitOfWork.GetRepositoryInstance<Tbl_Producto>().GetId(id);
            Tbl_Categoria cat  = _unitOfWork.GetRepositoryInstance<Tbl_Categoria>().GetId(auxProducto.Tbl_Categoria.CategoriaId);
            var auxImgs = _unitOfWork.GetRepositoryInstance<Tbl_imagen>().GetListaParametro(x => x.IdProducto == auxProducto.ProductoId).ToList();
            IEnumerable<Tbl_Producto> productosRelacionados = _unitOfWork.GetRepositoryInstance<Tbl_Producto>().GetListaParametro(x => x.CategoriaId == auxProducto.CategoriaId).ToList();

            //FILTRAR LOS PRODUCTOS RELACIONADOS QUE TIENEN STOCK
            productosRelacionados = productosRelacionados.Where(x => x.Cantidad > 0);

            //FILTRO PARA QUE NO MUESTRE EL MISMO PRODUCTO QUE ESTAMOS VIENDO
            productosRelacionados = productosRelacionados.Where(x => x.ProductoId != id);

            //CARAGAR IMAGENES RELACIONADAS AL PRODUCTO RELACIONADO
            var auxP = productosRelacionados.ToList();
            foreach (var item in auxP)
            {
                var img = _unitOfWork.GetRepositoryInstance<Tbl_imagen>().GetListaParametro(x => x.IdProducto == item.ProductoId).ToList();
                foreach (var it in img)
                {
                    item.Tbl_imagen.Add(it);
                }
            }
            productosRelacionados = auxP;

            //FILTRAR LOS PRODUCTOS RELACIONADOS QUE NO TIENEN LAS IMAGENES COMPLETAS
            productosRelacionados = productosRelacionados.Where(x => x.Tbl_imagen.Count >= 4);

            //CARAGAR CATEGORIA RELACIONADA AL PRODUCTO RELACIONADO
            var auxC = productosRelacionados.ToList();
            foreach (var item in auxC)
            {
                var auxCat = _unitOfWork.GetRepositoryInstance<Tbl_Categoria>().GetPorParametro(x => x.CategoriaId == item.CategoriaId);
                item.Tbl_Categoria = auxCat;
            }
            productosRelacionados = auxC;

            //CARGAR DATOS AL MODELO PARA LA VISTA
            DetalleProductoViewModels producto = new DetalleProductoViewModels {
                Cantidad = (int)auxProducto.Cantidad,
                Color = auxProducto.Color,
                NombreProducto = auxProducto.NombreProducto,
                Precio = (double)auxProducto.Precio,
                Talla = auxProducto.Talla,
                Descripcion = auxProducto.Descripcion,
                ProductoId = auxProducto.ProductoId,
                Categoria = cat.NombreCategoria,
                Imagenes = auxImgs,
                //ProductosRelacionados = productosRelacionados.ToList()
                ProductosRelacionados = _unitOfWork.GetRepositoryInstance<Tbl_Producto>().GetRegistros().ToList()
            };

            //INICIAR VISTA CON EL MODELO
            return View(producto);
        }
        public ActionResult ListaProductos(string buscar, int pagina = 1, CheckBoxList checkBoxList = null)
        {
            ViewBag.buscar = buscar;
            ViewBag.pag = pagina;
            var categorias = _unitOfWork.GetRepositoryInstance<CategoriaViewModels>().GetResuladoSqlProcedure("GetCategoriaView").ToList();
            ViewBag.Categorias = new CheckBoxList(categorias);


            int _RegistrosPorPagina = 3;
            PaginadorGenerico<Tbl_Producto> _PaginadorProductos;
           
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@search",buscar??(object)DBNull.Value)
            };

            // Almacenar la consulta de la tabla (objeto) 
            IEnumerable<Tbl_Producto> _productos = _unitOfWork.GetRepositoryInstance<Tbl_Producto>().GetResuladoSqlProcedure("GetBySearch @search", param).ToList();

            //FILTRAR LOS PRODUCTOS QUE TIENEN STOCK
            _productos = _productos.Where(x => x.Cantidad > 0);

            //CARAGAR IMAGENES RELACIONADAS AL PRODUCTO
            var auxProductos = _productos.ToList();
            foreach (var item in auxProductos)
            {
                var img = _unitOfWork.GetRepositoryInstance<Tbl_imagen>().GetListaParametro(x => x.IdProducto == item.ProductoId).ToList();
                foreach (var it in img)
                {
                    item.Tbl_imagen.Add(it);
                }
            }
            _productos = auxProductos;

            //FILTRAR LOS PRODUCTOS QUE NO TIENEN LA CANTIDAD MINIMA DE IMAGENES
            _productos = _productos.Where(x => x.Tbl_imagen.Count >= 4);

            //CARAGAR CATEGORIA RELACIONADA A LOS PRODUCTOS
            var auxC = _productos.ToList();
            foreach (var item in auxC)
            {
                item.Tbl_Categoria = _unitOfWork.GetRepositoryInstance<Tbl_Categoria>().GetPorParametro(x => x.CategoriaId == item.CategoriaId);
            }
            _productos = auxC;

            // Número total de registros de la tabla 
            int _TotalRegistros = _productos.Count();

            // Obtenemos la 'páginacion de registros' de la tabla
            _productos = _productos.OrderBy(x => x.NombreProducto)
                                                 .Skip((pagina - 1) * _RegistrosPorPagina)
                                                 .Take(_RegistrosPorPagina)
                                                 .ToList();
            // Número total de páginas de la tabla
            var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);

            _PaginadorProductos = new PaginadorGenerico<Tbl_Producto>
            {
                RegistrosPorPagina = _RegistrosPorPagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                Resultado = _productos

            };

            return View(_PaginadorProductos);
        }
    }
}
