using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VSBooking_JAZS_MVC.Models
{
    public class Search
    {
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}