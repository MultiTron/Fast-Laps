using FL.AppServices.Models.Response;

namespace FL.AppServices.Messaging.Response.Driver
{
    public class GetDriverResponse : ServiceResponseBase
    {
        required public List<DriverViewModel> Drivers { get; set; }
    }
}
