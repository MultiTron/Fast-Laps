using FL.AppServices.Messaging;
using FL.AppServices.Messaging.Request.Driver;
using FL.AppServices.Messaging.Response.Driver;

namespace FL.AppServices.Interfaces
{
    public interface IDriverManagementService
    {
        public GetDriverResponse GetDrivers();
        public GetDriverResponse GetDrivers(ServicePagingRequest request);
        public CreateDriverResponse CreateDriver(CreateDriverRequest request);
        public UpdateDriverResponse UpdateDriver(UpdateDriverRequest request);
        public DeleteDriverResponse DeleteDriver(DeleteDriverRequest request);
    }
}
