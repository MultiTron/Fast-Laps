using FL.AppServices.Models.Request;

namespace FL.AppServices.Messaging.Request.Driver
{
    public class CreateDriverRequest : ServiceRequestBase
    {
        public DriverModel Driver { get; set; }
        public CreateDriverRequest(DriverModel driver)
        {
            Driver = driver;
        }
    }
}
