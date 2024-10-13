using System.Text.Json;

namespace database_trade_study.Models
{
    public class TelemetryData
    {
        public int id { get; set; } 
        public string vehicleName { get; set; }       
        public int firesDestroyed { get; set; } 
        public long timestamp { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}