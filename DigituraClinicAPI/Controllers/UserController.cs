using DigituraClinicAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigituraClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DigituraClinicContext dc;
        public UserController(DigituraClinicContext _dc)
        {
            dc = _dc;
        }
        [HttpGet]
        public IActionResult Userlogin()
        {
            return Ok(dc.Users.ToList());
        }
        [HttpPost]
        public IActionResult login(User u)
        {
            var result = (from i in dc.Users
                          where i.UserName == u.UserName && i.Password == u.Password
                          select i).SingleOrDefault();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized();
            }

        }




    }
}
