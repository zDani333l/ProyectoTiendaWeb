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
    
    public partial class Tbl_Miembro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Miembro()
        {
            this.Tbl_Carro = new HashSet<Tbl_Carro>();
            this.Tbl_DetallesCompra = new HashSet<Tbl_DetallesCompra>();
            this.Tbl_MiembroRol = new HashSet<Tbl_MiembroRol>();
        }
    
        public int MiembroId { get; set; }
        public string Nombre { get; set; }
        public string EmailId { get; set; }
        public string PasswordId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Carro> Tbl_Carro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_DetallesCompra> Tbl_DetallesCompra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_MiembroRol> Tbl_MiembroRol { get; set; }
    }
}
