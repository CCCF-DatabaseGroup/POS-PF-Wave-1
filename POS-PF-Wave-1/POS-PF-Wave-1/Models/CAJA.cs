//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS_PF_Wave_1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAJA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAJA()
        {
            this.CAJEROS = new HashSet<CAJEROS>();
        }
    
        public int Id_caja { get; set; }
        public int Id_sucursal_caja { get; set; }
        public string Nombre_caja { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAJEROS> CAJEROS { get; set; }
        public virtual SUCURSAL SUCURSAL { get; set; }
    }
}
