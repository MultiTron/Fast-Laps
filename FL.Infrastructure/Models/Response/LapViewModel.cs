using System.ComponentModel;

namespace FL.Infrastructure.Models.Response
{
    public class LapViewModel
    {
        required public int Id { get; set; }
        [DisplayName("First sector")]
        public TimeSpan? Sector1 { get; set; }
        [DisplayName("Second sector")]
        public TimeSpan? Sector2 { get; set; }
        [DisplayName("Third sector")]
        public TimeSpan? Sector3 { get; set; }
        [DisplayName("Total time")]
        required public TimeSpan LapTime { get; set; }
        [DisplayName("Driver")]
        required public int DriverId { get; set; }
        [DisplayName("Driver name")]
        required public string DriverName { get; set; }

    }
}
