using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Horario.Domain.Abstract;
using Horario.Domain.Entities;

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

        public ViewResult Horario(String Nomina)
        {
           
            //--'01/08/2008 20:00' mes/dia/año hora
            DateTime diadia = DateTime.Now;
            //String dia = diadia.ToString();
            

            return View(context.regresarHorario(Nomina, diadia));
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