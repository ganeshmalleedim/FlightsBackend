using System;
using System.Collections.Generic;

namespace UserServices.Models
{
    public partial class BookFlight
    {
        public int Userid { get; set; }
        public int FlightNo { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int NOfSeats { get; set; }
        public string Meal { get; set; }
        public int SelectSeat { get; set; }
        public int Pnr { get; set; }
    }
}
