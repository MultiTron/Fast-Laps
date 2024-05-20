using FL.AppServices.Models.Request;

namespace FL.AppServices.Messaging.Request
{
    public class CreateCarRequest
    {
        public CarModel Car { get; set; }

        public CreateCarRequest(CarModel car)
        {
            Car = car;
        }
    }
}
