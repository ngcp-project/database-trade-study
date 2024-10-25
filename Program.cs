using Cassandra.Mapping;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

IMapper dbConnection = DBController.Instance();

await dbConnection.ExecuteAsync("DROP KEYSPACE IF EXISTS ngcpDatabase");

await dbConnection.ExecuteAsync("CREATE KEYSPACE IF NOT EXISTS ngcpDatabase WITH REPLICATION = { 'class' : 'SimpleStrategy', 'replication_factor' : '1' }");

await dbConnection.ExecuteAsync("USE ngcpDatabase");
await dbConnection.ExecuteAsync("CREATE TABLE IF NOT EXISTS ngcpDatabase.mockData (id int PRIMARY KEY, vehicleName text, firesDestroyed int)");

app.MapControllers();
app.UseWebSockets();
app.Run();
