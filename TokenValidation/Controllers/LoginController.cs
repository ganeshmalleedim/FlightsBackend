using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenValidation.IRepository;
using UserServices.Models;

namespace TokenValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class LoginController : ControllerBase
    {
        private ILogin _login;

        public LoginController(ILogin login)
        {
            _login = login;
        }
        [Route("validateLogin")]
        [HttpPost]

        public ActionResult validateLogin([FromBody]UserDetails user1)
        {
            AdminDbContext db = new AdminDbContext();
            var user = db.UserDetails.Where(m => m.UserName == user1.UserName && m.Password == user1.Password).FirstOrDefault();
            if (user==null)
            {
                return NotFound("User Not found please valid user name");
            }
            var token = _login.Builder(user.UserName);
            return Ok(token);
        }
        //public ActionResult validateLogin([FromBody] UserDetails user)
        //{
        //    if (user == null)
        //    {
        //        return NotFound("User Not found please valid user name");
        //    }
        //    var token = _login.Builder(user.UserName);
        //    return Ok(token);
        //}
    }
}
