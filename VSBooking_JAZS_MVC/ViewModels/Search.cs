using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VSBooking_JAZS_MVC.Models;

namespace VSBooking_JAZS_MVC.ViewModels
{
    public class Search
    {
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        public Reservation Reservation { get; set; }
    }
}