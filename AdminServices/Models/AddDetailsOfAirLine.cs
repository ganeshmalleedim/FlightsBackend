using System;
using System.Collections.Generic;

namespace AdminServices.Models
{
    public partial class AddDetailsOfAirLine
    {
        public int FlightNo { get; set; }
        public string FlightName { get; set; }
        public string FlightLogo { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string SheduleDays { get; set; }
        public string InstrumentsUsed { get; set; }
        public int? TotalNoOfBusinessClassSeats { get; set; }
        public int? TotalNoOfNonBusinessClassSeats { get; set; }
        public decimal? OnewayPrice { get; set; }
        public decimal? RoundtripPrice { get; set; }
        public int? NoOfRows { get; set; }
        public string MealVeg { get; set; }
        public string MealNonVeg { get; set; }
    }
}
