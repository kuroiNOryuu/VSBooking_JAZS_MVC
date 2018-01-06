using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VSBooking_JAZS_MVC.Models
{
    public class Reservation
    {
        public int IdReservation { get; set; }
        public string CustomerFirstname { get; set; }
        public string CustomerLastname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public  IList<Room> Room { get; set; }
    }
}