using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Horario.Domain.Entities;


namespace Horario.Domain.Abstract
{
    public interface IProfesorRepository
    {
        IEnumerable<PROFESOR> Profesores { get; }
        void SaveProfesor(PROFESOR profesor);
        PROFESOR DeleteProfesor(string nomina);
       IEnumerable<ProfesoresPagInicio_Result> Inicio { get; }
    }
}
