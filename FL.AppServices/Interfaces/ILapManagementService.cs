using FL.AppServices.Messaging.Request.Lap;
using FL.AppServices.Messaging.Response.Lap;

namespace FL.AppServices.Implementations
{
    public interface ILapManagementService
    {
        public GetLapResponse GetLaps();
        public CreateLapResponse CreateLap(CreateLapRequest request);
        public UpdateLapResponse UpdateLap(UpdateLapRequest request);
        public DeleteLapResponse DeleteLap(DeleteLapRequest request);
    }
}
