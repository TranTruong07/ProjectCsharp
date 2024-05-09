using LoginWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly RegistrationDbContext _context;
        public RegistrationController(RegistrationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("Registration")]
        public string Registration(Registration registration)
        {
            _context.registrations.Add(registration);
            try
            {
                if (_context.SaveChanges() == 1)
                {
                    return "Regis successfull";
                }
            }
            catch (Exception ex)
            {
                return "fail";
            }
            return "fail";
        }

        [HttpPost]
        [Route("login")]
        public IActionResult login(Login login)
        {
            var acc = _context.registrations.ToList().SingleOrDefault(x => x.Email.Equals(login.Email) && x.Password.Equals(login.Password));
            if(acc == null)
            {
                return NotFound();
            }
            return Ok(new {
                status = "ok",
                msg = "login successfull"
            });
        }
    }
}
