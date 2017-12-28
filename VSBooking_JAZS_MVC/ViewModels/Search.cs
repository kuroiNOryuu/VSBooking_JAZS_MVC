using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VSBooking_JAZS_MVC.Models;

namespace VSBooking_JAZS_MVC.ViewModels
{
    public class Search
    {
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }
    }
}