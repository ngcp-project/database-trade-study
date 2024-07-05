using System.Text.Json;

namespace database_trade_study.Models
{
    public class MockData
    {
        public string vehicleName { get; set; }
        public int firesDestroyed { get; set; }


        public MockData(string vehicleName, int firesDestroyed)
        {
            this.vehicleName = vehicleName;
            this.firesDestroyed = firesDestroyed;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}