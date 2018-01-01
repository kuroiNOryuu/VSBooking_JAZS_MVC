using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VSBooking_JAZS_MVC.Models
{
    public class Hotel
    {
        public int IdHotel { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Category { get; set; }
        [Display(Name = "WiFi")]
        public bool HasWiFi { get; set; }
        [Display(Name = "Parking")]
        public bool HasParking { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
    }
}