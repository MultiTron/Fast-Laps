using FL.Data.Context;
using FL.Data.Entities;
using FL.Infrastructure.Messaging;
using FL.Infrastructure.Messaging.Request.Lap;
using FL.Infrastructure.Messaging.Response.Lap;
using Microsoft.EntityFrameworkCore;

namespace FL.AppServices.Implementations
{
    public class LapManagementService : ILapManagementService
    {
        private readonly FLDbContext _context;
        public LapManagementService(FLDbContext context)
        {
            _context = context;
        }
        public CreateLapResponse CreateLap(CreateLapRequest request)
        {
            var driver = _context.Drivers.Find(request.Lap.DriverId);
            if (driver == null)
            {
                return new();
            }
            _context.Laps.Add(new Lap()
            {
                Sector1 = request.Lap.Sector1,
                Sector2 = request.Lap.Sector2,
                Sector3 = request.Lap.Sector3,
                LapTime = request.Lap.LapTime,
                DriverId = request.Lap.DriverId,
                Driver = driver,
                IsActive = true,
                CreatedOn = DateTime.UtcNow
            });
            _context.SaveChanges();
            return new();
        }

        public DeleteLapResponse DeleteLap(DeleteLapRequest request)
        {
            var entity = _context.Laps.Find(request.Id);
            if (entity == null)
            {
                return new();
            }
            _context.Laps.Remove(entity);
            _context.SaveChanges();
            return new();
        }

        public GetLapResponse GetLaps()
        {
            var response = new GetLapResponse() { Laps = new() };
            var laps = _context.Laps.Include("Driver").ToList();
            foreach (var lap in laps)
            {
                response.Laps.Add(new()
                {
                    Sector1 = lap.Sector1,
                    Sector2 = lap.Sector2,
                    Sector3 = lap.Sector3,
                    LapTime = lap.LapTime,
                    DriverName = $"{lap.Driver.FirstName} {lap.Driver.LastName}"
                });
            }
            return response;
        }

        public GetLapResponse GetLaps(ServicePagingRequest request)
        {
            var response = new GetLapResponse() { Laps = new() };
            var laps = _context.Laps.Include("Driver").ToList();
            foreach (var lap in laps.Skip((request.CurrentPage - 1) * request.ElementsPerPage).Take(request.ElementsPerPage))
            {
                response.Laps.Add(new()
                {
                    Sector1 = lap.Sector1,
                    Sector2 = lap.Sector2,
                    Sector3 = lap.Sector3,
                    LapTime = lap.LapTime,
                    DriverName = $"{lap.Driver.FirstName} {lap.Driver.LastName}"
                });
            }
            return response;
        }

        public UpdateLapResponse UpdateLap(UpdateLapRequest request)
        {
            var lap = _context.Laps.Find(request.Id);
            var driver = _context.Drivers.Find(request.Model.DriverId);
            if (lap == null || driver == null)
            {
                return new();
            }
            lap.Sector1 = (request.Model.Sector1 != lap.Sector1 && request.Model.Sector1 != null) ? request.Model.Sector1 : lap.Sector1;
            lap.Sector2 = (request.Model.Sector2 != lap.Sector2 && request.Model.Sector2 != null) ? request.Model.Sector2 : lap.Sector2;
            lap.Sector3 = (request.Model.Sector3 != lap.Sector3 && request.Model.Sector3 != null) ? request.Model.Sector3 : lap.Sector3;
            lap.LapTime = (request.Model.LapTime != lap.LapTime) ? request.Model.LapTime : lap.LapTime;
            lap.DriverId = request.Model.DriverId;
            lap.Driver = driver;
            lap.UpdatedOn = DateTime.UtcNow;
            _context.Update(lap);
            _context.SaveChanges();
            return new();
        }
    }
}
