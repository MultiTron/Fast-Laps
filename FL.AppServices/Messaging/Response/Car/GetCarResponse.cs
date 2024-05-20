using FL.AppServices.Models.Response;

namespace FL.AppServices.Messaging.Response
{
    public class GetCarResponse : ServiceResponseBase
    {
        required public List<CarViewModel> Cars { get; set; }
    }
}
