using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Horario.Domain.Abstract;
using Horario.Domain.Entities;
using Horario.Domain.Concrete;
using System.Globalization;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Data;

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

        [HttpPost]
        public ActionResult crearCita(string NominaProfeC, string NombrePersona, string Asunto, string Fecha, string HoraInicio, string HoraFin)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection("data source=JOSUE;initial catalog=ProyectoFinalBD;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework;"))
                {
                    SqlCommand command = new SqlCommand("esCitaValida", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@DiaCTexto", SqlDbType.NVarChar).Value = Fecha;
                    command.Parameters.Add("@HoraFCTexto", SqlDbType.NVarChar).Value = HoraFin;
                    command.Parameters.Add("@HoraICTexto", SqlDbType.NVarChar).Value = HoraInicio;
                    command.Parameters.Add("@NominaP", SqlDbType.NVarChar).Value = NominaProfeC;

                    command.Parameters.Add("@CitaCorrecta", SqlDbType.Bit).Direction = ParameterDirection.ReturnValue;
                    conn.Open();

                    command.ExecuteNonQuery();

                    int esCitaValida = int.Parse(command.Parameters["@CitaCorrecta"].Value.ToString());

                    if (esCitaValida==1)
                    {
                        CITA Cita = new CITA();
                        CultureInfo provider = CultureInfo.InvariantCulture;

                        Cita.Asunto = Asunto;
                        Cita.Fecha = DateTime.ParseExact(Fecha, "yyyy-MM-dd", provider);
                        Cita.HoraInicio = TimeSpan.ParseExact(HoraInicio, "g", provider);
                        Cita.HoraFin = TimeSpan.ParseExact(HoraFin, "g", provider);
                        Cita.NombrePersona = NombrePersona;
                        Cita.NominaP = NominaProfeC;

                        context.CITA.Add(Cita);
                        context.SaveChanges();

                        TempData["message"] = "Tu cita se creó correctamente.";
                        return RedirectToAction("List");
                        //return RedirectToAction("List", "Profesor", ViewBag);
                        //return View(repository);
                        //return View("List", repository);

                    }
                    else
                    {
                        TempData["message"] = "Lo sentimos, no se pudo crear tu cita. Asegurate de haber escrito bien los datos, de no haber puesto una fecha u hora que ya pasó, de que la fecha no sea Sábado o Domingo o que no intefiera con otra cita.";
                        return RedirectToAction("List");
                        //return RedirectToAction("List", "Profesor", null);
                        //return RedirectToAction("List", "Profesor", ViewBag);
                        //return View("List", repository);
                    }

                }
            }
            catch (Exception error)
            {
                TempData["message"] = string.Format("Lo sentimos, ha habido un error al crear la cita: "+error.Message);
                return RedirectToAction("List");
                //return RedirectToAction("List", "Profesor", null);
                //return RedirectToAction("List", "Profesor", ViewBag);
                //return View("List", repository);
            }
        }

        public ViewResult List()
        {
            //ViewBag.message = "";
            return View(repository);
        }
    }
}