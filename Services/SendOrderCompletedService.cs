using MassTransit;
using MinimalExample.Messages;

namespace MinimalExample.Services
{
    public class SendOrderCompletedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<SendOrderCompletedService> logger;
        private readonly IPublishEndpoint publishEndpoint;
        private Timer? timer = null;

        public SendOrderCompletedService(ILogger<SendOrderCompletedService> logger, IPublishEndpoint publishEndpoint)
        {
            this.logger = logger;
            this.publishEndpoint = publishEndpoint;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Timed Hosted Service running.");
            timer = new Timer(ExecuteAsync, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Timed Hosted Service is stopping.");
            timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private async void ExecuteAsync(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);

            int id = count;
            Order order = new Order() { Id= id};
            await publishEndpoint.Publish(order);

            logger.LogInformation($"Sending out order {id}");
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
