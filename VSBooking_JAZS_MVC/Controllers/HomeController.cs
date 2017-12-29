using System;
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
        
        
        public ActionResult Search()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult SearchResult(Search search)
        {
            List<SearchResult> results = new List<SearchResult>
            {
                new SearchResult { IdRoom = 1, Number = 101, Type = 1, Price = 99, HasTV = true, HasHairDryer = false, HotelName = "Octodure", Location = search.Hotel.Location },
                new SearchResult { IdRoom = 2, Number = 102, Type = 1, Price = 99, HasTV = true, HasHairDryer = true, HotelName = "Octodure", Location = search.Hotel.Location }
            };

            return View(results);
        }

        public ActionResult RoomDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<SearchResult> results = new List<SearchResult>();
            List<Picture> pictures = new List<Picture>
            {
                new Picture { IdPicture = 1, Url = @"~/res/img/img1.jpg" },
                new Picture { IdPicture = 2, Url = @"~/res/img/img2.jpg" },
                new Picture { IdPicture = 3, Url = @"~/res/img/img3.jpg" }
            };

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

            SearchResult result = new SearchResult();
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

        public ActionResult ResSummary(int id)
        {
            List<SearchResult> rooms = new List<SearchResult>();
            List<Picture> pictures = new List<Picture>
            {
                new Picture { IdRoom = 1, Url = @"~/res/img/img1.jpg" },
                new Picture { IdRoom = 2, Url = @"~/res/img/img2.jpg" },
                new Picture { IdRoom = 3, Url = @"~/res/img/img3.jpg" }
            };

            rooms.Add(new SearchResult
            {
                IdRoom = 1,
                Number = 101,
                Type = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor" +
                " incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, " +
                "sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Price = 99,
                HasTV = true,
                HasHairDryer = false,
                HotelName = "Octodure",
                Location = "Martigny",
                Pictures = pictures
            });

            rooms.Add(new SearchResult
            {
                IdRoom = 2,
                Number = 102,
                Type = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor" +
                " incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, " +
                "sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Price = 99,
                HasTV = true,
                HasHairDryer = true,
                HotelName = "Octodure",
                Location = "Martigny",
                Pictures = pictures
            });

            List<SearchResult> result = new List<SearchResult>();

            foreach(SearchResult sr in rooms)
            {
                if (sr.IdRoom == id)
                    result.Add(sr);
            }

            return View(result);
        }
    }
}