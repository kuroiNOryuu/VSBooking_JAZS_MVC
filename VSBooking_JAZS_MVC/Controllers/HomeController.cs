using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using VSBooking_JAZS_MVC.Async;
using VSBooking_JAZS_MVC.Models;
using VSBooking_JAZS_MVC.ViewModels;

namespace VSBooking_JAZS_MVC.Controllers
{
    public class HomeController : Controller
    {
        string singleRoom = "Single room";
        string doubleRoom = "Double room";

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
            // Get the list of all rooms at api/Rooms
            List<Room> rooms = RoomAsync.getRooms();

            // Put data into view model
            List<SearchResult> results = new List<SearchResult>();
            foreach (Room r in rooms)
            {
                string type;
                if (r.Type == 1)
                    type = singleRoom;
                else
                    type = doubleRoom;

                results.Add(new SearchResult
                {
                    Book = false,
                    IdRoom = r.IdRoom,
                    Number = r.Number,
                    Description = r.Description,
                    Type = type,
                    Price = r.Price,
                    HasTV = r.HasTV,
                    HasHairDryer = r.HasHairDryer,
                    HasWiFi = r.Hotel.HasWiFi,
                    HasParking = r.Hotel.HasParking,
                    HotelName = r.Hotel.Name,
                    Location = r.Hotel.Location,
                    Pictures = r.Picture
                });
            }

            SearchResultsVM resultsVM = new SearchResultsVM()
            {
                SearchResult = results
            };
            

            return View(resultsVM);
        }

        /* Page displaying the details for selected room */
        public ActionResult RoomDetails(int id)
        {
            List<Picture> pictures = new List<Picture>
            {
                new Picture { IdPicture = 1, Url = @"~/res/img/img1.jpg" },
                new Picture { IdPicture = 2, Url = @"~/res/img/img2.jpg" },
                new Picture { IdPicture = 3, Url = @"~/res/img/img3.jpg" }
            };           

            // Get room by id
            Room room = RoomAsync.getRoomById(id);

            string type;
            if (room.Type == 1)
                type = singleRoom;
            else
                type = doubleRoom;

            SearchResult result = new SearchResult
            {
                IdRoom = room.IdRoom,
                Number = room.Number,
                Description = room.Description,
                Type = type,
                Price = room.Price,
                HasTV = room.HasTV,
                HasHairDryer = room.HasHairDryer,
                HasWiFi = room.Hotel.HasWiFi,
                HasParking = room.Hotel.HasParking,
                HotelName = room.Hotel.Name,
                Location = room.Hotel.Location,
                Phone = room.Hotel.Phone,
                Email = room.Hotel.Email,
                Website = room.Hotel.Website,
                Pictures = pictures
            };

            if (result == null)
            {
                return HttpNotFound();
            }

            return View(result);
        }

        /* Page displaying a summary for the reservation of one room */
        public ActionResult SingleResSummary(int id)
        {
            List<Picture> pictures = new List<Picture>
            {
                new Picture { IdPicture = 1, Url = @"~/res/img/img1.jpg" },
                new Picture { IdPicture = 2, Url = @"~/res/img/img2.jpg" },
                new Picture { IdPicture = 3, Url = @"~/res/img/img3.jpg" }
            };

            // Get room by id
            Room room = RoomAsync.getRoomById(id);
            room.Picture = pictures;

            List<Room> rooms = new List<Room> { room };

            string type;
            if (room.Type == 1)
                type = singleRoom;
            else
                type = doubleRoom;

            ReservationVM result = new ReservationVM
            {
                Rooms = rooms,
                TotalPrice = room.Price
            };

            if (result == null)
            {
                return HttpNotFound();
            }

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