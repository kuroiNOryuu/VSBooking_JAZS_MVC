using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using VSBooking_JAZS_MVC.Models;

namespace VSBooking_JAZS_MVC.Async
{
    public class RoomAsync
    {
        private static string baseURI = "http://localhost:49962/api/Rooms/";

        // Get a list of rooms
        public static List<Room> getRooms()
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Task<string> response = client.GetStringAsync(baseURI);
            List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>(response.Result);

            return rooms;
        }

        public static Room getRoomById(int id)
        {
            string path = baseURI + "/" + id;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Task<string> response = client.GetStringAsync(path);
            Room room = JsonConvert.DeserializeObject<Room>(response.Result);

            return room;
        }
    }
}