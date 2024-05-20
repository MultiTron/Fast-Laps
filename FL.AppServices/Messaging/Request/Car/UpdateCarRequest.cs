using FL.AppServices.Models.Request;

namespace FL.AppServices.Messaging.Request
{
    public class UpdateCarRequest : ServiceIdBase
    {
        public CarModel Model { get; set; }
        public UpdateCarRequest(int id, CarModel model) : base(id)
        {
            Model = model;
        }
    }
}
