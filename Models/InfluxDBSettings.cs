using System.Text.Json;

namespace database_trade_study.Models

{

public class InfluxDBSettings
{
    public string Url { get; set; }
    public string Token { get; set; }
    public string Org { get; set; }
    public string Bucket { get; set; }
}

}