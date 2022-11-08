using DigituraClinicMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DigituraClinicMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly DigituraClinicContext dc;
        public LoginController(DigituraClinicContext _dc)
        {
           dc = _dc;
        }
       
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Userlogin(User u)
        {
            User logindata = new User();
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:44376/api/User", content))
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        {
                            string apiresponse = await response.Content.ReadAsStringAsync();
                            logindata = JsonConvert.DeserializeObject<User>(apiresponse);

                        }
                        HttpContext.Session.SetString("UserName", logindata.UserName);
                        return RedirectToAction("Home");
                    }
                    else
                    {
                        ViewBag.Message = "Invalid UserName or Password";
                        return View();
                    }
            }
        }
        public IActionResult Home()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            if (UserName != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("UserLogin");
            }
        }
   
        public IActionResult PatientPage()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            if (UserName != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("UserLogin");
            }
        }
        [HttpPost]
        public IActionResult PatientPage(PatientList pl)
        {
            dc.PatientLists.Add(pl);
            dc.SaveChanges();
            return RedirectToAction("Patients","Booking");
        }

        public IActionResult DoctorPage()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            if (UserName != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        [HttpPost]
        public IActionResult DoctorPage(DoctorList dl)
        {
            dc.DoctorLists.Add(dl);
            dc.SaveChanges();
            return RedirectToAction("MakeAppointment","Booking");
        }
      
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("UserLogin");
        }
    }
}
