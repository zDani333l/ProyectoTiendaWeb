using ProyectoWebAppTienda.DAL;
using ProyectoWebAppTienda.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWebAppTienda.Controllers
{
    public class AccesoController : Controller
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        // GET: Acceso
        public ActionResult Login()
        {
                return View();
        }

        [HttpPost]
        public ActionResult Login(string User, string Pass)
        {
            var oUsuario = (Tbl_Miembro)Session["User"];
            if (oUsuario == null)
            {
                try
                {
                    var oUser = _unitOfWork.GetRepositoryInstance<Tbl_Miembro>().GetRegistrosIQueryable().Where(d => d.EmailId == User.Trim() && d.PasswordId == Pass.Trim()).FirstOrDefault();
                    if (oUser == null)
                    {
                        ViewBag.Error = "Usuario o contraseña invalida";
                        return View();
                    }
                    Session["User"] = oUser;
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View();
                }
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult LogOff()
        {
            Session["User"] = null;
            return RedirectToAction("Index","Home");
        }
    }
}