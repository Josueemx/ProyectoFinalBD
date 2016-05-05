using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Horario.Domain.Abstract; // notar que esta línea permite usar la interface
using Horario.Domain.Entities; // notar que esta línea permite usar el código generado 


namespace Horario.Domain.Concrete
{
    public class EFProfesorRepository : IProfesorRepository
    {
        private HorarioEntities context = new HorarioEntities();

        public IEnumerable<PROFESOR> Profesores
        {
            get { return context.PROFESORs; }
        }

        public void SaveProfesor(PROFESOR profesor) // si le da RC-> Go to Definition (F12) puede ver la definición de la clase
        {
            PROFESOR dbEntry = context.PROFESORs.Find(profesor.Nomina);

            if (dbEntry != null) //Si encontró al profesor, actualiza los datos
            {
                dbEntry.Nomina = profesor.Nomina;
                dbEntry.Nombre = profesor.Nombre;
                dbEntry.Apellido = profesor.Apellido;
                dbEntry.Area = profesor.Area;
                dbEntry.Foto = profesor.Foto;
                dbEntry.Celular = profesor.Celular;
                dbEntry.Extension = profesor.Extension;
            }
            else //de lo contrario, lo añade
            {
                context.PROFESORs.Add(profesor);
            }
            context.SaveChanges();
        }

        public PROFESOR DeleteProfesor(string nomina)
        {
            PROFESOR dbEntry = context.PROFESORs.Find(nomina);
            if (dbEntry != null)
            {
                context.PROFESORs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public IEnumerable<ProfesoresPagInicio_Result> Inicio
        {
            get { return context.ProfesoresPagInicio(); }
        }


    }

}
