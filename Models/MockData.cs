using System.Security.Cryptography;
using System.Text.Json;

namespace database_trade_study.Models
{
    public class MockData
    {
        public int? id { get; set; }
        public string vehicleName { get; set; }
        public int firesDestroyed { get; set; }


        public MockData(int id, int firesDestroyed, string vehicleName)
        {
            this.id = id;
            this.vehicleName = vehicleName;
            this.firesDestroyed = firesDestroyed;
        }

        public MockData(string vehicleName, int firesDestroyed)
        {
            id = RandomNumberGenerator.GetInt32(int.MaxValue);
            this.vehicleName = vehicleName;
            this.firesDestroyed = firesDestroyed;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}