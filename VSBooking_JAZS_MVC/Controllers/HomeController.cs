using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VSBooking_JAZS_MVC.Models;
using VSBooking_JAZS_MVC.ViewModels;

namespace VSBooking_JAZS_MVC.Controllers
{
    public class HomeController : Controller
    {
        
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult SearchResult()
        {
            List<SearchResult> results = new List<SearchResult>();
            List<Hotel> hotels = new List<Hotel>();

            results.Add(new SearchResult { IdRoom = 1, Number = 101, Type = 1, Price = 99, HasTV = true, HasHairDryer = false, HotelName = "Octodure", Location = "Martigny" });
            results.Add(new SearchResult { IdRoom = 2, Number = 102, Type = 1, Price = 99, HasTV = true, HasHairDryer = true, HotelName = "Octodure", Location = "Martigny" });

            return View(results);
        }
    }
}