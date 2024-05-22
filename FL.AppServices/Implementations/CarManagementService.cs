using FL.AppServices.Interfaces;
using FL.Data.Context;
using FL.Infrastructure.Messaging;
using FL.Infrastructure.Messaging.Request;
using FL.Infrastructure.Messaging.Response;
using FL.Infrastructure.Messaging.Response.Car;

namespace FL.AppServices.Implementations
{
    public class CarManagementService : ICarManagementService
    {
        private readonly FLDbContext _context;
        public CarManagementService(FLDbContext context)
        {
            _context = context;
        }

        public GetCarResponse GetCars()
        {
            var response = new GetCarResponse() { Cars = new() };
            foreach (var car in _context.Cars)
            {
                response.Cars.Add(new()
                {
                    Brand = car.Brand,
                    Model = car.Model,
                    Power = car.Power,
                    Weight = car.Weight,
                    Class = car.Class
                });
            }
            return response;
        }

        public CreateCarResponse CreateCar(CreateCarRequest request)
        {
            _context.Cars.Add(new()
            {
                Brand = request.Car.Brand,
                Model = request.Car.Model,
                Power = request.Car.Power,
                Weight = request.Car.Weight,
                Class = request.Car.Class,
                IsActive = true,
                CreatedOn = DateTime.UtcNow
            });
            _context.SaveChanges();
            return new();
        }
        public UpdateCarResponse UpdateCar(UpdateCarRequest request)
        {
            var car = _context.Cars.Find(request.Id);
            if (car == null)
            {
                return new();
            }
            car.Brand = request.Model.Brand ?? car.Brand;
            car.Model = request.Model.Model ?? car.Model;
            car.Power = request.Model.Power >= 0 ? request.Model.Power : car.Power;
            car.Weight = request.Model.Weight >= 0 ? request.Model.Weight : car.Weight;
            car.Class = request.Model.Class ?? car.Class;
            car.UpdatedOn = DateTime.UtcNow;
            _context.Update(car);
            _context.SaveChanges();
            return new();
        }
        public DeleteCarResponse DeleteCar(DeleteCarRequest request)
        {
            var car = _context.Cars.Find(request.Id);
            if (car == null)
            {
                return new();
            }
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return new();
        }

        public GetCarResponse GetCars(ServicePagingRequest request)
        {
            var response = new GetCarResponse() { Cars = new() };
            foreach (var car in _context.Cars.Skip((request.CurrentPage - 1) * request.ElementsPerPage).Take(request.ElementsPerPage))
            {
                response.Cars.Add(new()
                {
                    Brand = car.Brand,
                    Model = car.Model,
                    Power = car.Power,
                    Weight = car.Weight,
                    Class = car.Class
                });
            }
            return response;
        }

        public GetCarResponse GetCar(int carId)
        {
            var response = new GetCarResponse() { Cars = new() };
            var car = _context.Cars.Find(carId) ?? throw new ArgumentOutOfRangeException("Element not found");
            response.Cars.Add(new()
            {
                Brand = car.Brand,
                Model = car.Model,
                Power = car.Power,
                Weight = car.Weight,
                Class = car.Class
            });
            return response;
        }
    }
}
