namespace FL.Infrastructure.Models.Request
{
    public class DriverModel
    {
        required public string FirstName { get; set; }
        required public string LastName { get; set; }
        public int CarId { get; set; }
    }
}
