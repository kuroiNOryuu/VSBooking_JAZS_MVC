﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VSBooking_JAZS_MVC.Models;
using VSBooking_JAZS_MVC.ViewModels;
using static VSBooking_JAZS_MVC.Models.ReservationDTO;

namespace VSBooking_JAZS_MVC.Controllers
{
    public class HomeController : Controller
    {
        string singleRoom = "Single room";
        string doubleRoom = "Double room";
        string baseURI = "http://localhost:49962/api";

        /* Search form used as home page */
        public ActionResult Search()
        {
            Session.Clear();
            return View();
        }

        /* */
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /* Page displaying the search results */
        public ActionResult SearchResult(Search result)
        {
            Search search;

            // Store search as a session to keep dates and location for reservation and back to results navigation
            Session["start_date"] = result.StartDate;
            Session["end_date"] = result.EndDate;
            Session["location"] = result.Location;
            Session["hair_dryer"] = result.HasHairDryer;
            Session["TV"] = result.HasTV;
            Session["WiFi"] = result.HasWiFi;
            Session["parking"] = result.HasParking;

            search = result;

            List<Room> rooms = new List<Room>();
            // Get the list of available rooms
            if (search.HasHairDryer == false && search.HasParking == false && search.HasTV == false && search.HasWiFi == false)
            {
                // Normal search
                rooms = GetRoomsByDateAndLocation(search.StartDate, search.EndDate, search.Location);
            }

            else
            {
                // Advanced search
                rooms = GetRoomsAdvancedSearch(search);
            }

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
                    RoomDescription = r.Description,
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
                SearchResult = results,
                StartDate = search.StartDate,
                EndDate = search.EndDate
            };


            return View(resultsVM);
        }

        /* Page displaying the details for selected room */
        public ActionResult RoomDetails(int id)
        {
            // Get room by id
            Room room = GetRoomById(id);

            string type;
            if (room.Type == 1)
                type = singleRoom;
            else
                type = doubleRoom;

            // Put data into view model
            SearchResult result = new SearchResult
            {
                IdRoom = room.IdRoom,
                Number = room.Number,
                RoomDescription = room.Description,
                Type = type,
                Price = room.Price,
                HasTV = room.HasTV,
                HasHairDryer = room.HasHairDryer,
                HasWiFi = room.Hotel.HasWiFi,
                HasParking = room.Hotel.HasParking,
                HotelName = room.Hotel.Name,
                HotelDescription = room.Hotel.Description,
                Location = room.Hotel.Location,
                Phone = room.Hotel.Phone,
                Email = room.Hotel.Email,
                Website = room.Hotel.Website,
                Pictures = room.Picture
            };

            if (result == null)
            {
                return HttpNotFound();
            }

            return View(result);
        }

        /* Set values for SearchResult when coming back from RoomDetails */
        public ActionResult BackToResult()
        {
            var startDate = (DateTime)Session["start_date"];
            var endDate = (DateTime)Session["end_date"];
            var location = (string)Session["location"];
            var hasHairDryer = (bool)Session["hair_dryer"];
            var hasTV = (bool)Session["TV"];
            var hasWiFi = (bool)Session["WiFi"];
            var hasParking = (bool)Session["parking"];

            return RedirectToAction("SearchResult", "Home", new
            {
                StartDate = startDate,
                EndDate = endDate,
                Location = location,
                HasHairDryer = hasHairDryer,
                HasTV = hasTV,
                HasWiFi = hasWiFi,
                HasParking = hasParking
            });
        }

        /* Page displaying a summary for the reservation of one room */
        public ActionResult SingleResSummary(int id)
        {
            // Get room by id
            Room room = GetRoomById(id);

            // Put data into view model
            List<Room> rooms = new List<Room> { room };

            string type;
            if (room.Type == 1)
                type = singleRoom;
            else
                type = doubleRoom;

            // Get dates from session
            var startDate = (DateTime)Session["start_date"];
            var endDate = (DateTime)Session["end_date"];

            ReservationVM result = new ReservationVM
            {
                Rooms = rooms,
                TotalPrice = room.Price,
                StartDate = startDate,
                EndDate = endDate
            };

            if (result == null)
            {
                return HttpNotFound();
            }

            return View(result);
        }

        /* Page displaying a summary for the reservation of several rooms */
        public ActionResult MultipleResSummary(SearchResultsVM searchResults)
        {
            // Get the selected rooms
            List<Room> rooms = new List<Room>();
            foreach (SearchResult r in searchResults.SearchResult)
            {
                if (r.Book == true)
                    rooms.Add(GetRoomById(r.IdRoom));
            }

            // Get total price
            decimal totalPrice = 0;

            // Put data into view model
            foreach (Room r in rooms)
                totalPrice += r.Price;

            // Get dates from session
            var startDate = (DateTime)Session["start_date"];
            var endDate = (DateTime)Session["end_date"];

            ReservationVM result = new ReservationVM
            {
                Rooms = rooms,
                TotalPrice = totalPrice,
                StartDate = startDate,
                EndDate = endDate
            };

            return View(result);
        }

        public ActionResult ResConfirmation(ReservationVM reservation)
        {

            List<Room> rooms = new List<Room>();
            HashSet<RoomsIdDTO> roomsId = new HashSet<RoomsIdDTO>();
            decimal totalPrice = 0;

            // Get reserved rooms
            for (int i = 0; i < reservation.Rooms.Count; i++)
            {
                rooms.Add(GetRoomById(reservation.Rooms[i].IdRoom));
                roomsId.Add(new RoomsIdDTO { IdRoom = reservation.Rooms[i].IdRoom });
                totalPrice += rooms[i].Price;
            }

            // Create reservation
            ReservationDTO res = new ReservationDTO
            {
                CustomerFirstname = reservation.Firstname,
                CustomerLastname = reservation.Lastname,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                RoomsId = roomsId
            };

            AddReservation(res);

            // Get id of new created reservation
            List<Reservation> retReservation = GetReservations();
            int size = retReservation.Count;

            // Put data into view model
            ReservationVM result = new ReservationVM
            {
                ReservationId = retReservation[size-1].IdReservation,
                Rooms = rooms,
                Firstname = reservation.Firstname,
                Lastname = reservation.Lastname,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                TotalPrice = totalPrice
            };

            return View(result);
        }

        public ActionResult CancelReservation(int id)
        {
            Reservation res = GetReservation(id);

            bool success = DeleteReservation(id, res.CustomerFirstname, res.CustomerLastname);

            var startDate = (DateTime)Session["start_date"];
            var endDate = (DateTime)Session["end_date"];

            ReservationVM result = new ReservationVM
            {
                ReservationId = id,
                Rooms = res.Room,
                StartDate = startDate,
                EndDate = endDate,
                Firstname = res.CustomerFirstname,
                Lastname = res.CustomerLastname
            };

            if (success == true)
            {
                return View(result);
            }

            result.Message = "Cancellation refused";

            return RedirectToAction("ResConfirmation", "Home", result);
            
        }

        //=========================================================================================================================

        // Get the list of rooms
        public List<Room> GetRooms()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Task<string> response = client.GetStringAsync(baseURI + "/Rooms");
            List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>(response.Result);

            return rooms;
        }

        // Get one room by its id
        public Room GetRoomById(int id)
        {
            string path = baseURI + "/Rooms/" + id;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Task<string> response = client.GetStringAsync(path);
            Room room = JsonConvert.DeserializeObject<Room>(response.Result);

            return room;
        }

        // Get the list of available rooms with normal search
        public List<Room> GetRoomsByDateAndLocation(DateTime startDate, DateTime endDate, string location)
        {
            string start = startDate.ToString("s");
            string end = endDate.ToString("s");
            string path = baseURI + "/Rooms?location=" + location + "&start=" + start + "&end=" + end;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Task<string> response = client.GetStringAsync(path);
            List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>(response.Result);

            return rooms;
        }

        // Get the list of available rooms with advanced search
        public List<Room> GetRoomsAdvancedSearch(Search search)
        {
            string start = search.StartDate.ToString("s");
            string end = search.EndDate.ToString("s");
            string path = baseURI + "/Rooms?location=" + search.Location + "&start=" + start + "&end=" + end 
                + "&tv=" + search.HasTV + "&hairdryer=" + search.HasHairDryer + "&wifi=" + search.HasWiFi + "&parking=" + search.HasParking;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Task<string> response = client.GetStringAsync(path);
            List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>(response.Result);

            return rooms;
        }

        // Create a reservation
        public bool AddReservation(ReservationDTO reservation)
        {
            string uri = baseURI + "/Reservations";
            using (HttpClient httpClient = new HttpClient())
            {
                string res = JsonConvert.SerializeObject(reservation);
                StringContent frame = new StringContent(res, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = httpClient.PostAsync(uri, frame);
                return response.Result.IsSuccessStatusCode;
            }
        }

        // Get the list of reservations
        public List<Reservation> GetReservations()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Task<string> response = client.GetStringAsync(baseURI + "/Reservations");
            List<Reservation> reservation = JsonConvert.DeserializeObject<List<Reservation>>(response.Result);

            return reservation;
        }

        // Get reservation by id
        public Reservation GetReservation(int id)
        {
            string path = baseURI + "/Reservations/" + id;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Task<string> response = client.GetStringAsync(path);
            Reservation reservation = JsonConvert.DeserializeObject<Reservation>(response.Result);

            return reservation;
        }

        // Remove reservation by id
        public bool DeleteReservation(int id, string firstname, string lastname)
        {
            string path = baseURI + "/Reservations?id=" + id + "&firstname=" + firstname + "&lastname=" + lastname;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<HttpResponseMessage> response = httpClient.DeleteAsync(path);
                return response.Result.IsSuccessStatusCode;
            }
        }
    }
}