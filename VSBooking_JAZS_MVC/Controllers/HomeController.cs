﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            results.Add(new SearchResult { IdRoom = 1, Number = 101, Type = 1, Price = 99, HasTV = true, HasHairDryer = false, HotelName = "Octodure", Location = "Martigny" });
            results.Add(new SearchResult { IdRoom = 2, Number = 102, Type = 1, Price = 99, HasTV = true, HasHairDryer = true, HotelName = "Octodure", Location = "Martigny" });

            return View(results);
        }

        public ActionResult RoomDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<SearchResult> results = new List<SearchResult>();
            List<Picture> pictures = new List<Picture>();

            pictures.Add(new Picture { IdRoom = 1, Url = @"~/res/img/img1.jpg" });
            pictures.Add(new Picture { IdRoom = 2, Url = @"~/res/img/img2.jpg" });
            pictures.Add(new Picture { IdRoom = 3, Url = @"~/res/img/img3.jpg" });

            results.Add(new SearchResult { IdRoom = 1, Number = 101, Type = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor" +
                " incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, " +
                "sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Price = 99, HasTV = true, HasHairDryer = false, HotelName = "Octodure", Location = "Martigny", Pictures = pictures });

            results.Add(new SearchResult { IdRoom = 2, Number = 102, Type = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor" +
                " incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, " +
                "sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Price = 99, HasTV = true, HasHairDryer = true, HotelName = "Octodure", Location = "Martigny", Pictures = pictures });

            SearchResult result = new ViewModels.SearchResult();
            foreach(SearchResult sr in results)
            {
                if (sr.IdRoom == id)
                    result = sr;
            }
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }
    }
}