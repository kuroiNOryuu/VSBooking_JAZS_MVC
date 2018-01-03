using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VSBooking_JAZS_MVC.Models
{
    public class Reservation
    {
        public int IdReservation { get; set; }
        [Display(Name = "Firstname")]
        public string CustomerFirstname { get; set; }
        [Display(Name = "Lastname")]
        public string CustomerLastname { get; set; }        
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }
        public IEnumerable<Room> Room { get; set; }
    }
}