//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoWebAppTienda.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_MiembroRol
    {
        public int MiembroRolId { get; set; }
        public Nullable<int> MiembroId { get; set; }
        public Nullable<int> RoleadoId { get; set; }
    
        public virtual Tbl_Miembro Tbl_Miembro { get; set; }
        public virtual Tbl_Roles Tbl_Roles { get; set; }
    }
}
