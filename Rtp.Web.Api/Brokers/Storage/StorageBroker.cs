using Microsoft.Extensions.Configuration;
using EFxceptions;
using Microsoft.EntityFrameworkCore;

namespace Rtp.Web.Api.Brokers.Storage
{
    public class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;
        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();

        } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = this.configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
            
        
    }
}