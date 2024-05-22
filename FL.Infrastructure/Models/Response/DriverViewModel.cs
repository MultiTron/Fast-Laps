namespace FL.Infrastructure.Models.Response
{
    public class DriverViewModel
    {
        required public string FirstName { get; set; }
        required public string LastName { get; set; }
        required public string CarBrand { get; set; }
        required public List<TimeSpan> LapTimes { get; set; }
    }
}
