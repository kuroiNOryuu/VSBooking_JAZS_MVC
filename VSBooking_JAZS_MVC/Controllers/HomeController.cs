using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using VSBooking_JAZS_MVC.Models;
using VSBooking_JAZS_MVC.ViewModels;

namespace VSBooking_JAZS_MVC.Controllers
{
    public class HomeController : Controller
    {
        string baseURI = "http://localhost:49962/api/Rooms/";

        /* Search form used as home page */
        public ActionResult Search()
        {
            return View();
        }

        /* */
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /* Page displaying the search results */
        public ActionResult SearchResult(Search search)
        {
            /*HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Task<string> response = client.GetStringAsync(baseURI);
            List <Room> rooms = JsonConvert.DeserializeObject<List<Room>>(response.Result);*/

            List<SearchResult> results = new List<SearchResult>();
            List<Picture> pictures = new List<Picture>
            {
                new Picture { IdPicture = 1, Url = @"~/res/img/img1.jpg" },
                new Picture { IdPicture = 2, Url = @"~/res/img/img2.jpg" },
                new Picture { IdPicture = 3, Url = @"~/res/img/img3.jpg" }
            };

            results.Add(new SearchResult
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

            results.Add(new SearchResult
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

            /*foreach (Room r in rooms)
            {
                results.Add(new SearchResult
                {
                    Book = false,
                    IdRoom = r.IdRoom,
                    Number = r.Number,
                    Description = r.Description,
                    Type = r.Type,
                    Price = r.Price,
                    HasTV = r.HasTV,
                    HasHairDryer = r.HasHairDryer,
                    HasWiFi = r.Hotel.HasWiFi,
                    HasParking = r.Hotel.HasParking,
                    HotelName = r.Hotel.Name,
                    Location = r.Hotel.Location,
                    Pictures = r.Picture
                });
            }*/

            return View(results);
        }

        /* Page displaying the details for selected room */
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

            results.Add(new SearchResult
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

            results.Add(new SearchResult
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

            SearchResult result = new SearchResult();
            foreach (SearchResult sr in results)
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

        /* Page displaying a summary for the reservation of one room */
        public ActionResult SingleResSummary(int id)
        {
            List<Hotel> hotels = new List<Hotel>();
            hotels.Add(new Hotel
            {
                IdHotel = 1,
                Name = "Octodure",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor" +
                " incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, " +
                "sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Location = "Martigny",
                Category = 1,
                HasWiFi = true,
                HasParking = true
            });

            List<Room> room = new List<Room>();
            room.Add(new Room
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
                Hotel = hotels[0]
            });

            decimal totalPrice = room[0].Price;

            ViewModels.ReservationVM result = new ViewModels.ReservationVM
            {
                Rooms = room,
                TotalPrice = totalPrice
            };

            return View(result);
        }

        /* Page displaying a summary for the reservation of several rooms */
        public ActionResult MultipleResSummary(List<SearchResult> searchResults)
        {
            List<Hotel> hotels = new List<Hotel>();
            hotels.Add(new Hotel
            {
                IdHotel = 1,
                Name = "Octodure",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor" +
                " incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, " +
                "sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Location = "Martigny",
                Category = 1,
                HasWiFi = true,
                HasParking = true
            });

            List<Room> rooms = new List<Room>
            {
            new Room
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
                Hotel = hotels[0]
            }
            };

            decimal totalPrice = 0;

            foreach (Room r in rooms)
                totalPrice += r.Price;

            ViewModels.ReservationVM result = new ViewModels.ReservationVM
            {
                Rooms = rooms,
                TotalPrice = totalPrice
            };

            return View(result);
        }

        public ActionResult ResConfirmation(ReservationVM reservation)
        {
            List<Hotel> hotels = new List<Hotel>();
            hotels.Add(new Hotel
            {
                IdHotel = 1,
                Name = "Octodure",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor" +
                " incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, " +
                "sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Location = "Martigny",
                Category = 1,
                HasWiFi = true,
                HasParking = true
            });

            List<Room> rooms = new List<Room>();
            rooms.Add(new Room
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
                Hotel = hotels[0]
            });

            decimal totalPrice = 0;

            foreach (Room r in rooms)
                totalPrice += r.Price; ;

            ViewModels.ReservationVM result = new ViewModels.ReservationVM
            {
                Rooms = rooms,
                Firstname = reservation.Firstname,
                Lastname = reservation.Lastname,
                TotalPrice = totalPrice,
                ReservationId = 1
            };

            return View(result);
        }
    }
}