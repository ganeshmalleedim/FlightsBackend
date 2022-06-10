using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserServices.Models;

namespace UserServices.Controllers
{
   
    public class FlightsController : ControllerBase
    {

        public IConfiguration _config;
        public FlightsController(IConfiguration configuration)
        {
            _config = configuration;
        }

        //User login
       
        [HttpPost]
        [Route("api/Flights/UserLogin")]
        
        public IActionResult UserLogin(string username, string password)
        {
            //try
            //{
            //    using (AdminDbContext db = new AdminDbContext())
            //    {

            //        var user = db.UserDetails.Where(m => m.UserName == username && m.Password == password).FirstOrDefault();
            //        if (user != null)
            //        {
            //            return Ok(user);
            //        }
            //        else
            //        {
            //            return NotFound("there is no user avaliable");
            //        }
            //        //  if (user == null)
            //        //  {
            //        //      return NotFound("User Not found please valid user name");
            //        //  }
            //        //  db.SaveChanges();
            //        //  return Ok("Admin login successfully");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex);
            //}

            if (username == null)
            {
                return NotFound(new
                {
                    success = 0,
                    message = "Please check your Credentials",
                    token = string.Empty
                });
            }
            else
            {
                var db = new AdminDbContext();
                var user = db.UserDetails.Where(a =>
                    a.UserName == username
                    && a.Password == password
                    ).FirstOrDefault();
                var token = GenerateTokenUsingJwt(username);
                if (user != null)
                {
                    return Ok(new
                    {
                        success = 1,
                        message = "Logged In Successfully",
                        token = token
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        success = 0,
                        message = "Please check your Credentials",
                        token = string.Empty
                    });
                }
            }

        }

        public string GenerateTokenUsingJwt(string userName)
        {
            var signinngKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(signinngKey, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var jwt = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMinutes(3)
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        [HttpPost]
        [Route("api/Flights/UserRegister")]
        public int UserRegister([FromBody] UserDetails details)
        {
            using (AdminDbContext db = new AdminDbContext())
            {
                db.UserDetails.Add(details);
               int count= db.SaveChanges();
                return count;
            }

        }


        //search for flights
        [HttpPost]
        [Route("api/Flights/SearchFlights")]
        //public List<Flights> SearchFlights(string source,string destination)
        //{
        //    using (UserDbContext db = new UserDbContext())
        //    {
        //        //var obj=db.Flights.Where(m => m.Source == source && m.Destination == destination).FirstOrDefault();
        //        var FlightLists = (from x in db.Flights
        //                           where x.Source == source && x.Destination == destination
        //                           select x).ToList();
        //        return FlightLists;
        //    }

             
        //}

        //serach flights through admin db

       
        [HttpPost]
        [Route("api/Flights/FlightSearch")]
        public List<AddDetailsOfAirLine> FlightSearch(string source, string destination)
        {
            using (AdminDbContext db = new AdminDbContext())
            {
                //var obj=db.Flights.Where(m => m.Source == source && m.Destination == destination).FirstOrDefault();
                var FlightLists = (from x in db.AddDetailsOfAirLine
                                   where x.Source == source && x.Destination == destination
                                   select x).ToList();
                return FlightLists;
            }


        }

        //[HttpGet]
        //[Route("api/Flights/getBookedTickets")]
        //public IEnumerable<BookFlight> getBookedTickets()
        //{
        //    using (UserDbContext db = new UserDbContext())
        //    {
        //       return db.BookFlight.ToList();
        //    }

        //}

        // BookFlight
        [HttpPost]
        [Route("api/Flights/TicketBooking")]
        public string TicketBooking([FromBody] TicketBookingDetails book)
        {
            using (UserDbContext db = new UserDbContext())
            {
                Random random = new Random();
                book.Pnr = random.Next(0, 1000000);
                db.TicketBookingDetails.Add(book);
                db.SaveChanges();
                return "ticket booked successfull";
            }

        }

       // getticket details by pnr
        [HttpGet]
        [Route("api/Flights/ticketbypnr")]
        public BookFlight ticketbypnr(int pnr)
        {
            using (UserDbContext db = new UserDbContext())
            {
                var ticket = db.BookFlight.Where(m => m.Pnr == pnr).FirstOrDefault();
                return ticket;
            }
        }

        //get flight by flightNo
        [HttpGet]
        [Route("api/Flights/getFlightByFlightNo")]
        public AddDetailsOfAirLine getFlightByFlightNo(int flightno)
       {
            using (AdminDbContext db = new AdminDbContext())
            {
                //var obj=db.Flights.Where(m => m.Source == source && m.Destination == destination).FirstOrDefault();
                var FlightLists = db.AddDetailsOfAirLine.Find(flightno);
                return FlightLists;
            }

        }

        //getTicket details by Email
        [HttpGet]
        [Route("api/Flights/ticketByEmail")]
        public BookFlight ticketByEmail(string email)
        {
            using (UserDbContext db = new UserDbContext())
           {
               var Ticket = db.BookFlight.Where(m => m.Email == email).FirstOrDefault();
              return Ticket;
           }
        }

    }
}
