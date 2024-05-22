using FL.Infrastructure.Models.Response;

namespace FL.Infrastructure.Messaging.Response
{
    public class GetCarResponse : ServiceResponseBase
    {
        required public List<CarViewModel> Cars { get; set; }
    }
}
