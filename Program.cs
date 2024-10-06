using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var mongoConnectionString = builder.Configuration.GetConnectionString("Mongodb");
    return new MongoClient(mongoConnectionString);
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.UseWebSockets();
app.Run();
