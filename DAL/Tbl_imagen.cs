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
    
    public partial class Tbl_imagen
    {
        public int IdImagenes { get; set; }
        public string NombreImagen { get; set; }
        public string DirImagen { get; set; }
        public Nullable<int> IdProducto { get; set; }
    
        public virtual Tbl_Producto Tbl_Producto { get; set; }
    }
}