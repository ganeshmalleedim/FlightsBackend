using AdminServices.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminServices.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class AdminController1 : ControllerBase
    {

        // POST api/<AdminController1>
        [HttpPost]
        [Route("api/Admin/AdminLogin")]
        public ActionResult AdminLogin(string username,string password)
        {
            try
            {
                using (AdminDbContext db = new AdminDbContext())
                {

                    var user=  db.AdminLogin.Where(m =>m.AdminUn==username && m.AdminPassword==password).FirstOrDefault();
                    if(user != null)
                    {
                        return Ok(user);
                    }
                    else
                    {
                        return NotFound("there is no admin avaliable");
                    }
                    //  if (user == null)
                    //  {
                    //      return NotFound("User Not found please valid user name");
                    //  }
                    //  db.SaveChanges();
                    //  return Ok("Admin login successfully");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
           
        }


        // GET: api/<AdminController1>
        [HttpGet]
        [Route("api/Admin/getAirlines")]
        public IEnumerable<AddDetailsOfAirLine> getAirlines()
        {
            AdminDbContext obj = new AdminDbContext();
           return obj.AddDetailsOfAirLine.ToList();
            //return new string[] { "revalue1", "value2" };
        }

        // GET api/<AdminController1>/5
        [HttpGet]
        [Route("api/Admin/getAirlinesById")]
        public AddDetailsOfAirLine getAirlinesById(int id)
        {
           using(AdminDbContext db = new AdminDbContext())
            {
                return db.AddDetailsOfAirLine.Find(id);
            }
        }

        // POST api/<AdminController1>
        [HttpPost]
        [Route("api/Admin/addAirline")]
        public string addAirline([FromBody] AddDetailsOfAirLine details)
        {
            
           using(AdminDbContext db = new AdminDbContext())
            {
                db.AddDetailsOfAirLine.Add(details);
                 db.SaveChanges();
                return "Airline Added successfully";
            }
        }

        // PUT api/<AdminController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminController1>/5
        [HttpDelete]
        [Route("api/Admin/BlockAirline")]
        public string BlockAirline(int id)
        {
            using (AdminDbContext db = new AdminDbContext())
            {
                var details = db.AddDetailsOfAirLine.Find(id);
                db.AddDetailsOfAirLine.Remove(details);
                db.SaveChanges();
                return "Airline blocked succefully";
            }
        }
    }
}
