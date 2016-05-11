using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Horario.Domain.Entities;
using System.Data.Entity.Core.Objects;

namespace Horario.Domain.Concrete
{
    public class HorarioViewModel
    {
        private HorarioEntities context = new HorarioEntities();
        public PROFESOR Profe { get; set; }
        public DateTime Dia { get; set; }
        public DateTime DiaMas7 { get; set; }
        public DateTime DiaMenos7 { get; set; }
        public string FechaC { get; set; }
        public string HoraIC { get; set; }
        public string HoraFC { get; set; }
        public string NombrePersonaC { get; set; }
        public string NominaProfeC { get; set; }
        public string AsuntoC { get; set; }

        public HorarioViewModel(PROFESOR Profe, DateTime Dia, DateTime DiaMas7, DateTime DiaMenos7)
        {
            this.Profe = Profe;
            this.Dia = Dia;
            this.DiaMas7 = DiaMas7;
            this.DiaMenos7 = DiaMenos7;
        }

        public IEnumerable<regresarHorario_Result> regresarHorario()
        {
            return context.regresarHorario(Profe.Nomina, Dia);
        }

        public IEnumerable<regresarEncabezadoSemana_Result> regresarEncabezadosSemana()
        {
            return context.regresarEncabezadoSemana(Dia);
        }

        public string regresarDiaMas7()
        {
            return DiaMas7.ToString("yyyy-MM-dd");
        }

        public string regresarDiaMenos7()
        {
            return DiaMenos7.ToString("yyyy-MM-dd");
        }
    }
}

