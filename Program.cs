using MinimalExample.Integrations;
using MinimalExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMassTransitIntegration();
builder.Services.AddHostedService<SendOrderCompletedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.Run();
