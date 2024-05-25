namespace FL.Infrastructure.Models.Response
{
    public class LapViewModel
    {
        required public int Id { get; set; }
        public TimeSpan? Sector1 { get; set; }
        public TimeSpan? Sector2 { get; set; }
        public TimeSpan? Sector3 { get; set; }
        required public TimeSpan LapTime { get; set; }
        required public string DriverName { get; set; }

    }
}
