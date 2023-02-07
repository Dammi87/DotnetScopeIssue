using MinimalExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISomeScopedService>(x => new ScopedService());
builder.Services.AddHostedService<SomeHostedService>();

var app = builder.Build();

app.Run();
