namespace MockTestApi.Services
{
    public class VMService : IVMService
    {
        private readonly Dictionary<string, string> _statuses = new Dictionary<string, string>();

        public string Create()
        {
            string requestId = Guid.NewGuid().ToString();
            _statuses.Add(requestId, "Creating");
            Task.Run(async () =>
            {
                await Task.Delay(new Random().Next(5000, 10000));
                _statuses[requestId] = "Created";
            });

            return requestId;
        }

        public string GetStatus(string requestId)
        {
            if(!_statuses.ContainsKey(requestId))
            {
                return null;
            }
            return _statuses[requestId];
        }
    }
}
