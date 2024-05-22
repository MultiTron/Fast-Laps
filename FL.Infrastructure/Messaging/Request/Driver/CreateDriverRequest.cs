using FL.Infrastructure.Models.Request;

namespace FL.Infrastructure.Messaging.Request.Driver
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
