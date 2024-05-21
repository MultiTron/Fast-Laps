using FL.AppServices.Interfaces;
using FL.AppServices.Messaging;
using FL.AppServices.Messaging.Request.Driver;
using FL.AppServices.Messaging.Response.Driver;
using FL.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FL.AppServices.Implementations
{
    public class DriverManagementService : IDriverManagementService
    {
        private readonly FLDbContext _context;
        public DriverManagementService(FLDbContext context)
        {
            _context = context;
        }
        public CreateDriverResponse CreateDriver(CreateDriverRequest request)
        {
            var car = _context.Cars.Find(request.Driver.CarId);
            if (car == null)
            {
                return new();
            }
            _context.Drivers.Add(new()
            {
                FirstName = request.Driver.FirstName,
                LastName = request.Driver.LastName,
                CarId = request.Driver.CarId,
                Car = car,
                IsActive = true,
                CreatedOn = DateTime.UtcNow
            });
            _context.SaveChanges();
            return new();
        }

        public DeleteDriverResponse DeleteDriver(DeleteDriverRequest request)
        {
            var driver = _context.Drivers.Find(request.Id);
            if (driver == null)
            {
                return new();
            }
            _context.Drivers.Remove(driver);
            _context.SaveChanges();
            return new();
        }

        public GetDriverResponse GetDrivers()
        {
            var response = new GetDriverResponse() { Drivers = new() };
            var drivers = _context.Drivers.Include("Car").Include("Laps").ToList();
            foreach (var driver in drivers)
            {
                var lapTimes = new List<TimeSpan>();
                if (driver.Laps != null && driver.Laps.Count > 0)
                {
                    foreach (var lap in driver.Laps)
                    {
                        lapTimes.Add(lap.LapTime);
                    }
                }
                response.Drivers.Add(new()
                {
                    FirstName = driver.FirstName,
                    LastName = driver.LastName,
                    CarBrand = $"{driver.Car.Brand} {driver.Car.Model}",
                    LapTimes = lapTimes
                });
            }
            return response;
        }

        public GetDriverResponse GetDrivers(ServicePagingRequest request)
        {
            var response = new GetDriverResponse() { Drivers = new() };
            var drivers = _context.Drivers.Include("Car").Include("Laps").ToList();
            foreach (var driver in drivers.Skip((request.CurrentPage - 1) * request.ElementsPerPage).Take(request.ElementsPerPage))
            {
                var lapTimes = new List<TimeSpan>();
                if (driver.Laps != null && driver.Laps.Count > 0)
                {
                    foreach (var lap in driver.Laps)
                    {
                        lapTimes.Add(lap.LapTime);
                    }
                }
                response.Drivers.Add(new()
                {
                    FirstName = driver.FirstName,
                    LastName = driver.LastName,
                    CarBrand = $"{driver.Car.Brand} {driver.Car.Model}",
                    LapTimes = lapTimes
                });
            }
            return response;
        }

        public UpdateDriverResponse UpdateDriver(UpdateDriverRequest request)
        {
            var driver = _context.Drivers.Find(request.Id);
            var car = _context.Cars.Find(request.Model.CarId);
            if (driver == null || car == null)
            {
                return new();
            }
            driver.FirstName = request.Model.FirstName ?? driver.FirstName;
            driver.LastName = request.Model.LastName ?? driver.LastName;
            driver.CarId = request.Model.CarId;
            driver.Car = car;
            _context.Drivers.Update(driver);
            _context.SaveChanges();
            return new();
        }
    }
}
