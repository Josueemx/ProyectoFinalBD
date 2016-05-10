using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Horario.Domain.Abstract;
using Horario.Domain.Entities;
using Horario.Domain.Concrete;
using System.Globalization;

namespace Horario.WebUI.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor
        /*public ActionResult Index()
        {
            return View();
        }*/

        private HorarioEntities context = new HorarioEntities();

        public IProfesorRepository repository;


        public ProfesorController(IProfesorRepository profesorRepository)
        {
            repository = profesorRepository;
        }

        public ViewResult Horario(String Nomina, string DiaTexto)
        {

            //--'01/08/2008 20:00' mes/dia/año hora
            //int Semana = int.Parse(SemanaTexto);
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime Dia = DateTime.ParseExact(DiaTexto, "yyyy-MM-dd", provider);
            DateTime DiaMenos7 = Dia.AddDays(-7.0);
            DateTime DiaMas7 = Dia.AddDays(7.0);
            /*switch (Semana)
            {
                case -1:
                    Dia = Dia.AddDays(-7.0);
                    break;
                case 1:
                    Dia = Dia.AddDays(7.0);
                    break;
            }*/
            //var CosaE = Tuple.Create(21.5, 23.0);

            HorarioViewModel Cosa = new HorarioViewModel(context.PROFESOR.Find(Nomina), Dia, DiaMas7, DiaMenos7);

            //return View(context.regresarHorario(Nomina, diadia));
            return View(Cosa);
        }

        public ViewResult List()
        {
            return View(repository);
        }
        /*
        public ViewResult Inicio()
        {
            return View(repository.Inicio);
        }*/

    }
}