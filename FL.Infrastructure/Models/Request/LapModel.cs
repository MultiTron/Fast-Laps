namespace FL.Infrastructure.Models.Request
{
    public class LapModel
    {
        public TimeSpan? Sector1 { get; set; }
        public TimeSpan? Sector2 { get; set; }
        public TimeSpan? Sector3 { get; set; }
        required public TimeSpan LapTime { get; set; }
        required public int DriverId { get; set; }
    }
}
