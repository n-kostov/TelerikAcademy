using System.Data.Entity;

namespace Logs.Data
{
    public class LogsDB : DbContext
    {
        public LogsDB()
            : base("LogsDB")
        {
        }

        public DbSet<SearchLog> SearchLogs { get; set; }
    }
}
