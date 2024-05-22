using FL.Infrastructure.Messaging;
using FL.Infrastructure.Messaging.Request;
using FL.Infrastructure.Messaging.Response;
using FL.Infrastructure.Messaging.Response.Car;

namespace FL.AppServices.Interfaces
{
    public interface ICarManagementService
    {
        public GetCarResponse GetCar(int carId);
        public GetCarResponse GetCars();
        public GetCarResponse GetCars(ServicePagingRequest request);
        public CreateCarResponse CreateCar(CreateCarRequest request);
        public UpdateCarResponse UpdateCar(UpdateCarRequest request);
        public DeleteCarResponse DeleteCar(DeleteCarRequest request);
    }
}
