using FL.Infrastructure.Messaging;
using FL.Infrastructure.Messaging.Request.Lap;
using FL.Infrastructure.Messaging.Response.Lap;

namespace FL.AppServices.Implementations
{
    public interface ILapManagementService
    {
        public GetLapResponse GetLaps();
        public GetLapResponse GetLap(int id);
        public GetLapResponse GetLaps(ServicePagingRequest request);
        public CreateLapResponse CreateLap(CreateLapRequest request);
        public UpdateLapResponse UpdateLap(UpdateLapRequest request);
        public DeleteLapResponse DeleteLap(DeleteLapRequest request);
    }
}
