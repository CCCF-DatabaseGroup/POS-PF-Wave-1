//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS_PF_Wave_1
{
    using System;
    using System.Collections.Generic;
    
    public partial class FARMACIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FARMACIA()
        {
            this.SUCURSAL = new HashSet<SUCURSAL>();
            this.TRABAJA_EN = new HashSet<TRABAJA_EN>();
        }
    
        public int Id_farmacia { get; set; }
        public string Nombre_farmacia { get; set; }
        public string Correo_electronico { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUCURSAL> SUCURSAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRABAJA_EN> TRABAJA_EN { get; set; }
    }
}
