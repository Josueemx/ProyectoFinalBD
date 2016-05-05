using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Horario.Domain.Abstract;


namespace Horario.WebUI.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor
        /*public ActionResult Index()
        {
            return View();
        }*/

        public IProfesorRepository repository;


        public ProfesorController(IProfesorRepository profesorRepository)
        {
            repository = profesorRepository;
        }

        public ViewResult List()
        {
            return View(repository);
        }

        public ViewResult Inicio()
        {
            return View(repository.Inicio);
        }

    }
}