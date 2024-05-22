using FL.Infrastructure.Models.Response;

namespace FL.Infrastructure.Messaging.Response.Driver
{
    public class GetDriverResponse : ServiceResponseBase
    {
        required public List<DriverViewModel> Drivers { get; set; }
    }
}
