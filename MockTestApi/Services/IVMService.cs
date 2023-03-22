namespace MockTestApi.Services
{
    public interface IVMService
    {
        string Create();
        string GetStatus(string requestId);
    }
}
