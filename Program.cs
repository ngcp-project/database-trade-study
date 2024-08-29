using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using database_trade_study.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure InfluxDB settings and add InfluxDBService
builder.Services.Configure<InfluxDBSettings>(builder.Configuration.GetSection("InfluxDBSettings"));
builder.Services.AddSingleton<InfluxDBService>();

var app = builder.Build();

// Map controllers
app.MapControllers();

// Enable WebSockets
app.UseWebSockets();

// Run the application
app.Run();
