using DigituraClinicMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DigituraClinicMVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly DigituraClinicContext dc;
        public BookingController(DigituraClinicContext _dc)
        {
            dc = _dc;


        }
        public IActionResult Patients()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            if (UserName != null)
            {
                var patients = dc.PatientLists.ToList();
                return View(patients);
            }
            else
            {
                return RedirectToAction("UserLogin","Login");
            }
        }
       
        public IActionResult DeletePatients(int id)
        {
            PatientList pl = dc.PatientLists.Find(id);
            return View(pl);
        }
        [HttpPost]
        [ActionName("DeletePatients")]
        public IActionResult DeletePatient(int id)
        {
            PatientList pl = dc.PatientLists.Find(id);
            dc.PatientLists.Remove(pl);
            dc.SaveChanges();
            return RedirectToAction("Patients");
        }

        public IActionResult MakeAppointment()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            if (UserName != null)
            {
                var appointment = dc.DoctorLists.ToList();
                return View(appointment);
            }
            else
            {
                return RedirectToAction("UserLogin", "Login");
            }
        }
        public IActionResult DeleteDoctor(int id)
        {
            DoctorList doctor = dc.DoctorLists.Find(id);
            return View(doctor);
        }
        [HttpPost]
        [ActionName("DeleteDoctor")]
        public IActionResult DeleteDoctors(int id)
        {
            DoctorList dl = dc.DoctorLists.Find(id);
            dc.DoctorLists.Remove(dl);
            dc.SaveChanges();
            return RedirectToAction("MakeAppointment");
        }

        public IActionResult Book(int id)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            if (UserName != null)
            {
                ViewBag.Patients = from i in dc.PatientLists
                                   select i;
                HttpContext.Session.SetInt32("doc", id);
                DoctorList dl = dc.DoctorLists.Find(id);


                AppointmentClass ac = new();
                {
                    ac.DoctorId = id;
                    ac.Specialization = dl.Specialization;
                    ac.VisitingHours = dl.VisitingHours;
                    ac.DoctorName = dl.FirstName + " " + dl.LastName;
                }


                return View(ac);
            }
            else
            {
                return RedirectToAction("UserLogin", "Login");
            }
        }

        [HttpPost]
        public IActionResult Book(AppointmentClass act)
        {
                ScheduleAppointment sa = new();
                    var doc = HttpContext.Session.GetInt32("doc");
                    DoctorList dl = dc.DoctorLists.Find(doc);
                    {
                        sa.DoctorId = dl.DoctorId;
                        sa.Specialization = dl.Specialization;
                        sa.AppointmentTime = act.AppointmentTime;
                        sa.PatientId = act.PatientId;
                        sa.AppointmentDate = act.AppointmentDate;
                    }
                    dc.ScheduleAppointments.Add(sa);
                    dc.SaveChanges();
                    return RedirectToAction("CancelAppointmentPage");
                }

        public IActionResult CancelAppointmentPage()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            if (UserName != null)
            {
                var booking = (from i in dc.ScheduleAppointments
                               where i.AppointmentDate>=DateTime.Today select i).ToList();
                return View(booking);
            }
            else
            {
                return RedirectToAction("UserLogin", "Login");
            }
        }

        public IActionResult Delete(int id)
        {
            ScheduleAppointment sa = dc.ScheduleAppointments.Find(id);
            return View(sa);    
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            ScheduleAppointment sa= dc.ScheduleAppointments.Find(id);
            dc.ScheduleAppointments.Remove(sa);
            dc.SaveChanges();
            return RedirectToAction("CancelAppointmentPage");
        }
    }
}
