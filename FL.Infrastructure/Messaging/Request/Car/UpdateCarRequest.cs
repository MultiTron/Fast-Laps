using FL.Infrastructure.Models.Request;

namespace FL.Infrastructure.Messaging.Request
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
