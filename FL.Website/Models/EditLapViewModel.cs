namespace FL.Website.Models
{
    public class EditLapViewModel
    {
        public Dictionary<int, string> Drivers { get; set; }
        public int Id { get; set; }
        public TimeSpan Sector1 { get; set; }
        public TimeSpan Sector2 { get; set; }
        public TimeSpan Sector3 { get; set; }
        public TimeSpan LapTime { get; set; }
        public int DriverId { get; set; }
    }
}
