using FL.Infrastructure.Models.Response;

namespace FL.Infrastructure.Messaging.Response.Lap
{
    public class GetLapResponse : ServiceResponseBase
    {
        required public List<LapViewModel> Laps { get; set; }
    }
}
