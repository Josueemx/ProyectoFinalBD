//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Horario.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class DICA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DICA()
        {
            this.CarrerasDeDICAs = new HashSet<CarrerasDeDICA>();
        }
    
        public string Nomina { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarrerasDeDICA> CarrerasDeDICAs { get; set; }
        public virtual PROFESOR PROFESOR { get; set; }
    }
}
