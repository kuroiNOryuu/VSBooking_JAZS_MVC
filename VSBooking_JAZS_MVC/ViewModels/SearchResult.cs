using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VSBooking_JAZS_MVC.Models;

namespace VSBooking_JAZS_MVC.ViewModels
{
    public class SearchResult
    {
        public bool Book { get; set; }
        /*public Room Room { get; set; }
        public Hotel Hotel { get; set; }
        public Reservation Reservation { get; set; }*/

        public int IdRoom { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "TV")]
        public bool HasTV { get; set; }
        [Display(Name = "Hair dryer")]
        public bool HasHairDryer { get; set; }
        [Display(Name = "WiFi")]
        public bool HasWiFi { get; set; }
        [Display(Name = "Parking")]
        public bool HasParking { get; set; }
        [Display(Name = "Hotel")]
        public string HotelName { get; set; }
        public string Location { get; set; }
        public IEnumerable<Picture> Pictures { get; set; }
    }
}