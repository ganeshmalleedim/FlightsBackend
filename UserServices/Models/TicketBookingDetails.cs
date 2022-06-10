using System;
using System.Collections.Generic;

namespace UserServices
{
    public partial class TicketBookingDetails
    {
        public int Userid { get; set; }
        public int FlightNo { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public long Phone { get; set; }
        public string FlightName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string StartDateTime { get; set; }
        public string EndDatrTime { get; set; }
        public int SeatNo { get; set; }
        public decimal Price { get; set; }
        public int Pnr { get; set; }
    }
}
