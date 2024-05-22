using FL.AppServices.Messaging;
using FL.AppServices.Messaging.Request;
using FL.AppServices.Messaging.Response;
using FL.AppServices.Messaging.Response.Car;

namespace FL.AppServices.Interfaces
{
    public interface ICarManagementService
    {
        public GetCarResponse GetCars();
        public GetCarResponse GetCars(ServicePagingRequest request);
        public CreateCarResponse CreateCar(CreateCarRequest request);
        public UpdateCarResponse UpdateCar(UpdateCarRequest request);
        public DeleteCarResponse DeleteCar(DeleteCarRequest request);
    }
}
