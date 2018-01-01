namespace VSBooking_JAZS_MVC.Models
{
    public class Picture
    {
        public int IdPicture { get; set; }
        public string Url { get; set; }
        public int IdRoom { get; set; }
        public Room Room { get; set; }
    }
}