using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VSBooking_JAZS_MVC.Models
{
    public class Room
    {
        public int IdRoom { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "TV")]
        public bool HasTV { get; set; }
        [Display(Name = "Hair dryer")]
        public bool HasHairDryer { get; set; }
        public int IdHotel { get; set; }
        public Hotel Hotel { get; set; }
        public IEnumerable<Picture> Pictures { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}