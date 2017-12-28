using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSBooking_JAZS_MVC.Models;

namespace VSBooking_JAZS_MVC.ViewModels
{
    public class SearchResult
    {
        public bool Book { get; set; }
        public int IdRoom { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public decimal Price { get; set; }
        public bool HasTV { get; set; }
        public bool HasHairDryer { get; set; }
        public bool HasWiFi { get; set; }
        public bool HasParking { get; set; }
        public string HotelName { get; set; }
        public string Location { get; set; }
        public IEnumerable<Picture> Pictures { get; set; }
    }
}