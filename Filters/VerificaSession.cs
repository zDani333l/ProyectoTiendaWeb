using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWebAppTienda.Controllers;
using ProyectoWebAppTienda.DAL;
using ProyectoWebAppTienda.Repository;

namespace ProyectoWebAppTienda.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private Tbl_Miembro oUsuario;
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);

            oUsuario = (Tbl_Miembro)HttpContext.Current.Session["User"];
            if (oUsuario != null)
            {
                var rol = _unitOfWork.GetRepositoryInstance<Tbl_MiembroRol>().GetRegistrosIQueryable().Where(x => x.MiembroId == oUsuario.MiembroId && x.RoleadoId == 1).FirstOrDefault();
                if (rol != null)
                {
                    if (filterContext.Controller is AccesoController == true)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Administrador/Dashboard");
                    }
                    if (filterContext.Controller is HomeController == true)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Administrador/Dashboard");
                    }
                }
                else
                {
                    if (filterContext.Controller is AccesoController == true)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Home/Index");
                    }
                    if (filterContext.Controller is AdministradorController == true)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Home/Index");
                    }
                }
                
                    
            }

               
        }
    }
}