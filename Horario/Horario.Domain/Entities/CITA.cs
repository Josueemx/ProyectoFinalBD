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
    
    public partial class CITA
    {
        public int Folio { get; set; }
        public string NombrePersona { get; set; }
        public string NominaP { get; set; }
        public string Asunto { get; set; }
        public System.TimeSpan HoraInicio { get; set; }
        public System.TimeSpan HoraFin { get; set; }
        public System.DateTime Fecha { get; set; }
    
        public virtual PROFESOR PROFESOR { get; set; }
    }
}
