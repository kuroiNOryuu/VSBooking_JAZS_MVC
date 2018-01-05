using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VSBooking_JAZS_MVC.Models;

namespace VSBooking_JAZS_MVC.ViewModels
{
    public class ReservationVM
    {
        public IList<Room> Rooms { get; set; }
        [Required]
        public string Firstname {get;set;}
        [Required]
        public string Lastname { get; set; }
        public decimal TotalPrice { get; set; }
        public int ReservationId { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = false)]
        public DateTime EndDate { get; set; }
    }
}