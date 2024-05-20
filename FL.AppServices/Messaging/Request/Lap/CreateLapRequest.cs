using FL.AppServices.Models.Request;

namespace FL.AppServices.Messaging.Request.Lap
{
    public class CreateLapRequest
    {
        public LapModel Lap { get; set; }
        public CreateLapRequest(LapModel lap)
        {
            Lap = lap;
        }
    }
}
