using FL.Infrastructure.Models.Request;

namespace FL.Infrastructure.Messaging.Request.Lap
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
