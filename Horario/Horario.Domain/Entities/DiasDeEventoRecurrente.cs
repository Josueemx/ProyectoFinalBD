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
    
    public partial class DiasDeEventoRecurrente
    {
        public int IDEvento { get; set; }
        public string Dia { get; set; }
    
        public virtual EVENTO_RECURRENTE EVENTO_RECURRENTE { get; set; }
    }
}