using FL.AppServices.Models.Request;

namespace FL.AppServices.Messaging.Request.Lap
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
