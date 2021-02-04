using ProyectoWebAppTienda.DAL;
using ProyectoWebAppTienda.Models;
using ProyectoWebAppTienda.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWebAppTienda.Controllers
{
    public class CompraController : Controller
    {
        private GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        // GET: Compra
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Carrito()
        {
            
            return View();      
        }

        public void ProcesoAgregarCarrito(int productId)
        {
            if (Session["cart"] == null)
            {
                List<Articulo> cart = new List<Articulo>();
                var producto = _unitOfWork.GetRepositoryInstance<Tbl_Producto>().GetId(productId);
                var img = _unitOfWork.GetRepositoryInstance<Tbl_imagen>().GetListaParametro(x => x.IdProducto == productId).ToList();
                foreach (var it in img)
                {
                    producto.Tbl_imagen.Add(it);
                }

                cart.Add(new Articulo()
                {
                    Producto = producto,
                    Cantidad = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Articulo> cart = (List<Articulo>)Session["cart"];
                var count = cart.Count();
                var producto = _unitOfWork.GetRepositoryInstance<Tbl_Producto>().GetId(productId);
                var img = _unitOfWork.GetRepositoryInstance<Tbl_imagen>().GetListaParametro(x => x.IdProducto == productId).ToList();
                foreach (var it in img)
                {
                    producto.Tbl_imagen.Add(it);
                }
                for (int i = 0; i < count; i++)
                {
                    if (cart[i].Producto.ProductoId == productId)
                    {
                        int cant = cart[i].Cantidad;
                        cart.Remove(cart[i]);
                        cart.Add(new Articulo()
                        {
                            Producto = producto,
                            Cantidad = cant + 1
                        });
                        break;
                    }
                    else
                    {
                        var prd = cart.Where(x => x.Producto.ProductoId == productId).SingleOrDefault();
                        if (prd == null)
                        {
                            cart.Add(new Articulo()
                            {
                                Producto = producto,
                                Cantidad = 1
                            });
                        }
                    }
                }
                Session["cart"] = cart;

            }
        }

        public void ProcesoEliminarCarrito(int productId)
        {
            List<Articulo> cart = (List<Articulo>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Producto.ProductoId == productId)
                {
                    cart.Remove(item);
                    break;
                }
            }
            Session["cart"] = cart;
        }

        public ActionResult AgregarCarrito(int productId, string search, int pag = 1)
        {
            ProcesoAgregarCarrito(productId);
            return RedirectToAction("ListaProductos", "Producto", new { pagina = pag,buscar = search });
        }
        public ActionResult EliminarCarrito(int productId,string search, int pag = 1)
        {
            ViewBag.buscar = search;
            ViewBag.pag = pag;
            ProcesoEliminarCarrito(productId);
            return RedirectToAction("ListaProductos", "Producto", new { pagina = pag, buscar = search });
        }
    }
}