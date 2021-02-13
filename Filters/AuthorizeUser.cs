using ProyectoWebAppTienda.DAL;
using ProyectoWebAppTienda.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWebAppTienda.Filters
{
    //[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)] ACTIVAR SI QUIERO AUTORIZACION POR METODOS
    public class AuthorizeUser : AuthorizeAttribute
    {
        private Tbl_Miembro oUsuario;
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        //private dbTiendaOnlineBicicletasEntities db = new dbTiendaOnlineBicicletasEntities();
        private int idRol;
        public AuthorizeUser(int idRol = 0)
        {
            this.idRol = idRol;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String nombreOperacion = "";

            try
            {
                oUsuario = (Tbl_Miembro)HttpContext.Current.Session["User"];

                var lstMisOperaciones = _unitOfWork.GetRepositoryInstance<Tbl_MiembroRol>().GetRegistrosIQueryable().Where(m => m.MiembroRolId == oUsuario.MiembroId && m.RoleadoId == idRol);

                //var lstMisOperaciones = from m in db.Tbl_MiembroRol
                //                        where m.MiembroRolId == oUsuario.MiembroId
                //                            && m.RoleadoId == idRol
                //                        select m;


                if (lstMisOperaciones.ToList().Count() == 0)
                {
                    var oOperacion = _unitOfWork.GetRepositoryInstance<Tbl_Roles>().GetId(idRol);
                    //var oOperacion = db.Tbl_Roles.Find(idRol);
                    nombreOperacion = getNombreDeOperacion(idRol);
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOperacion + "&msjeErrorExcepcion=");
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOperacion + "&msjeErrorExcepcion=" + ex.Message);
            }
        }
        public string getNombreDeOperacion(int idOperacion)
        {
            var ope = _unitOfWork.GetRepositoryInstance<Tbl_Roles>().GetRegistrosIQueryable().Where(op => op.RoleadoId == idOperacion);
            //var ope = from op in db.Tbl_Roles
            //          where op.RoleadoId == idOperacion
            //          select op.NombreRol;
            String nombreOperacion;
            try
            {
                nombreOperacion = ope.First().NombreRol;
            }
            catch (Exception)
            {
                nombreOperacion = "f";
            }
            return nombreOperacion;
        }
        
    }
}