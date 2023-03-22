namespace ServiceConsumers.Services
{
    public interface IClientService
    {
        string Create();
        string GetStatus(string requestId);
    }
}
