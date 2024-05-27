using System.ComponentModel;

namespace FL.Infrastructure.Models.Response
{
    public class DriverViewModel
    {
        required public int Id { get; set; }
        [DisplayName("First name")]
        required public string FirstName { get; set; }
        [DisplayName("Last name")]
        required public string LastName { get; set; }
        [DisplayName("Car")]
        public int CarId { get; set; }
        [DisplayName("Car brand")]
        required public string CarBrand { get; set; }
        [DisplayName("Lap times")]
        required public List<TimeSpan> LapTimes { get; set; }
    }
}
