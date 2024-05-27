using System.ComponentModel;

namespace FL.Website.Models
{
    public class CreateLapViewModel
    {
        public Dictionary<int, string> Drivers { get; set; }
        [DisplayName("First sector")]
        public TimeSpan Sector1 { get; set; }
        [DisplayName("Second sector")]
        public TimeSpan Sector2 { get; set; }
        [DisplayName("Third sector")]
        public TimeSpan Sector3 { get; set; }
        [DisplayName("Total time")]
        public TimeSpan LapTime { get; set; }
        [DisplayName("Driver")]
        public int DriverId { get; set; }
    }
}
