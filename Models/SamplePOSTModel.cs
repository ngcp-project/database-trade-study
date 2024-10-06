using System.Text.Json;

namespace database_trade_study.Models
{
    public class SamplePOSTModel
    {
        public string sampleName { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        
    }
}