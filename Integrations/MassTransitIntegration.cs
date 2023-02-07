using MassTransit;
using MinimalExample.Messages;

namespace MinimalExample.Integrations
{
    public static class MassTransitIntegration
    {
        private const string SERVICE_EXCHANGE = "innova";

        /// <summary>
        /// Add the massTransit related services.
        /// </summary>
        /// <param name="services">Service collection being built.</param>
        /// <param name="configuration">Application configuration.</param>
        /// <returns>The service collection has all the services needed to use MassTransit.</returns>
        public static IServiceCollection AddMassTransitIntegration(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {

                x.UsingRabbitMq((context, cfg) =>
                {
                    // Configure location of RabbitMQ
                    cfg.Host("localhost", "/", h => {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            // Set options to wait for bus
            services.AddOptions<MassTransitHostOptions>()
                .Configure(options =>
                {
                    // if specified, waits until the bus is started before
                    // returning from IHostedService.StartAsync
                    // default is false
                    options.WaitUntilStarted = true;

                    // if specified, limits the wait time when starting the bus
                    options.StartTimeout = TimeSpan.FromSeconds(10);

                    // if specified, limits the wait time when stopping the bus
                    options.StopTimeout = TimeSpan.FromSeconds(30);
                });

            Console.WriteLine("Done configuring MassTransit!");
            return services;
        }
    }
}
