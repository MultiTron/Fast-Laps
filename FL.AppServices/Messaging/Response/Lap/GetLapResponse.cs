using FL.AppServices.Models.Response;

namespace FL.AppServices.Messaging.Response.Lap
{
    public class GetLapResponse : ServiceResponseBase
    {
        required public List<LapViewModel> Laps { get; set; }
    }
}
