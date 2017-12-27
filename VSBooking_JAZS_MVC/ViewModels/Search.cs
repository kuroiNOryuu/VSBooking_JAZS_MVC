using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSBooking_JAZS_MVC.Models;

namespace VSBooking_JAZS_MVC.ViewModels
{
    public class Search
    {
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}