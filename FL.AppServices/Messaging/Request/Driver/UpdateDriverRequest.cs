using FL.AppServices.Models.Request;

namespace FL.AppServices.Messaging.Request.Driver
{
    public class UpdateDriverRequest : ServiceIdBase
    {
        public DriverModel Model { get; set; }
        public UpdateDriverRequest(int id, DriverModel model) : base(id)
        {
            Model = model;
        }
    }
}
