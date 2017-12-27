using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VSBooking_JAZS_MVC.Models
{
    public class Reservation
    {
        public int IdReservation { get; set; }
        public string ConsumerLastname { get; set; }
        public string ConsumerFirstName { get; set; }
        public DateTime StarttDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdRoom { get; set; }
    }
}