namespace FL.Infrastructure.Messaging
{
    public class ServicePagingRequest : ServiceRequestBase
    {
        public ServicePagingRequest(int currentPage, int elementsPerPage)
        {
            CurrentPage = currentPage;
            ElementsPerPage = elementsPerPage;
        }

        public int CurrentPage { get; set; }
        public int ElementsPerPage { get; set; }


    }
}
