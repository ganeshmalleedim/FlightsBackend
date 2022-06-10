using System;
using System.Collections.Generic;

namespace AdminServices.Models
{
    public partial class Flights
    {
        public int FlightNo { get; set; }
        public string FlightName { get; set; }
        public string FDate { get; set; }
        public string FTime { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Oneway { get; set; }
        public string RoundTrip { get; set; }
        public decimal? OnewayPrice { get; set; }
        public decimal? RoundtripPrice { get; set; }
        public decimal? DicountPrice { get; set; }
    }
}
