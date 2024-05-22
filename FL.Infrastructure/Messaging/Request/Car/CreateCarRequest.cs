using FL.Infrastructure.Models.Request;

namespace FL.Infrastructure.Messaging.Request
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
