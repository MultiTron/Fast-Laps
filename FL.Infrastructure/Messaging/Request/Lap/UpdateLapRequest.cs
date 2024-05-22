using FL.Infrastructure.Models.Request;

namespace FL.Infrastructure.Messaging.Request.Lap
{
    public class UpdateLapRequest : ServiceIdBase
    {
        public LapModel Model { get; set; }
        public UpdateLapRequest(int id, LapModel model) : base(id)
        {
            Model = model;
        }
    }
}
