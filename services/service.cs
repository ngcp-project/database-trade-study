using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using Microsoft.Extensions.Options;
using database_trade_study.Models;
using System.Threading.Tasks;

public class InfluxDBService
{
    private readonly InfluxDBClient _client;
    private readonly string _bucket;
    private readonly string _org;

    public InfluxDBService(IOptions<InfluxDBSettings> settings)
    {
        var influxDBSettings = settings.Value;
        _client = InfluxDBClientFactory.Create(influxDBSettings.Url, influxDBSettings.Token.ToCharArray());
        _bucket = influxDBSettings.Bucket;
        _org = influxDBSettings.Org;
    }

    public async Task WriteDataAsync(MockData data)
    {
        var writeApi = _client.GetWriteApiAsync();
        var point = PointData.Measurement("mock_data")
            .Tag("vehicleName", data.vehicleName)
            .Field("firesDestroyed", data.firesDestroyed)
            .Field("timeStamp", data.Timestamp)
            .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

        await writeApi.WritePointAsync(point, _bucket, _org);
        var endTime = DateTime.UtcNow;
        // Console.WriteLine($"Data write took: {endTime - startTime}");
    }
}
