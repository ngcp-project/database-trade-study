using Microsoft.EntityFrameworkCore;
using database_trade_study.Models;

namespace database_trade_study.Context
{
    public class TelemetryContext : DbContext
    {

        public TelemetryContext(DbContextOptions<TelemetryContext> options)
            : base(options)
        {
        }

        public DbSet<TelemetryData> telemetry { get; set; }
        
    }
}
