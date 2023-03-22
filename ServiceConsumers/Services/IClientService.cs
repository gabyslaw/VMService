namespace ServiceConsumers.Services
{
    public interface IClientService
    {
        Task<string> Create();
        Task<string> GetStatus(string requestId);
    }
}
