using LogMessageApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LogMessageApp.Data
{
    public class ApiContext:DbContext
    {
        public DbSet<LogMessage> logMessage { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) 
            : base(options)
        {

        }
    }
}
