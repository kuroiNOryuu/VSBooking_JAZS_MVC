using System;
using System.ComponentModel.DataAnnotations;

namespace VSBooking_JAZS_MVC.ViewModels
{
    public class Search
    {
        [DisplayFormat(DataFormatString = "{0:s}")]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:s}")]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }
        [Required]
        public string Location { get; set; }
        [Display(Name = "TV")]
        public bool HasTV { get; set; }
        [Display(Name = "Hair dryer")]
        public bool HasHairDryer { get; set; }
        [Display(Name = "WiFi")]
        public bool HasWiFi { get; set; }
        [Display(Name = "Parking")]
        public bool HasParking { get; set; }
    }
}