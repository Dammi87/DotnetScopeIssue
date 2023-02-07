namespace MinimalExample.Services
{
    public class SomeHostedService : IHostedService
    {
        private ISomeScopedService _service;

        public SomeHostedService(ISomeScopedService service)
        {
            _service = service;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Start Async..");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stop Async..");
        }
    }
}
