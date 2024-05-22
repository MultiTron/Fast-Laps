using FL.Infrastructure.Messaging;
using FL.Infrastructure.Messaging.Request.Driver;
using FL.Infrastructure.Messaging.Response.Driver;

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
