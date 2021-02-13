using Newtonsoft.Json;
using ProyectoWebAppTienda.DAL;
using ProyectoWebAppTienda.Filters;
using ProyectoWebAppTienda.Models;
using ProyectoWebAppTienda.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWebAppTienda.Controllers
{
    [AuthorizeUser(idRol: 1)] //ROL 1 ES PARA ADMINISTRADOR
    public class AdministradorController : Controller
    {

        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Categorias()
        {
            List<Tbl_Categoria> allcategories = _unitOfWork.GetRepositoryInstance<Tbl_Categoria>().GetRegistros().Where(i => i.IsDelete == false).ToList();
            return View(allcategories);
        }

        public ActionResult AgregarCategoria()
        {
            return ActualizarCategoria(0);
        }

        public ActionResult ActualizarCategoria(int CategoriaId = -1)
        {
            Categoria cd;
            if (CategoriaId == -1)
            {
                cd = JsonConvert.DeserializeObject<Categoria>(JsonConvert.SerializeObject(_unitOfWork.GetRepositoryInstance<Tbl_Categoria>().GetId(CategoriaId)));
            }
            else
            {
                cd = new Categoria();
            }
            return View("ActualizarCategoria", cd);
        }

        public ActionResult Producto()
        {
            List<Tbl_Producto> allproducts = _unitOfWork.GetRepositoryInstance<Tbl_Producto>().GetRegistros().Where(i => i.IsDelete == false).ToList();
            return View(allproducts);
        }

       // [AuthorizeUser(idRol: 1)]
        public ActionResult ProductEdit(int ProductoId)
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Producto>().GetId(ProductoId));
        }

        [HttpPost]
        public ActionResult ProductEdit(Tbl_Producto tbl)
        {
            _unitOfWork.GetRepositoryInstance<Tbl_Producto>().Actualizar(tbl);
            return RedirectToAction("Producto");
        }

        public ActionResult ProductAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProductAdd(Tbl_Producto tbl)
        {
            _unitOfWork.GetRepositoryInstance<Tbl_Producto>().Agregar(tbl);
            return RedirectToAction("Producto");
        }
    }
}