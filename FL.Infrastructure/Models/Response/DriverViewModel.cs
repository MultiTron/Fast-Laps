namespace FL.Infrastructure.Models.Response
{
    public class DriverViewModel
    {
        required public int Id { get; set; }
        required public string FirstName { get; set; }
        required public string LastName { get; set; }
        public int CarId { get; set; }
        required public string CarBrand { get; set; }
        required public List<TimeSpan> LapTimes { get; set; }
    }
}
