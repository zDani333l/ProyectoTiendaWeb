using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWebAppTienda.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }
    }
}