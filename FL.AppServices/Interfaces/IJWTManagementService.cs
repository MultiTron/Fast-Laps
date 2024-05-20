namespace FL.AppServices.Interfaces
{
    public interface IJWTManagementService
    {
        string? Authenticate(string clientId, string secret);
    }
}
