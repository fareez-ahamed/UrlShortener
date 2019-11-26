using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UrlShortener.Data
{
    public class DataContext : DbContext
    {

        private IConfiguration _config;
        public DataContext(IConfiguration config): base()
        {
            _config = config;
        }       

        public DbSet<Url> Urls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySql(_config.GetConnectionString("MySql"));
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Url>().HasKey( x => x.Id );
        }
    }
}