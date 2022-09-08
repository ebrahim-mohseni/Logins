using Logins.Domain.Classes;
using Logins.Domain.Configs;
using Microsoft.EntityFrameworkCore;

namespace Logins.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {                        
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UsersConfig());
            builder.ApplyConfiguration(new LookupTypeConfig());
            builder.ApplyConfiguration(new LookupConfig());
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<LookupType> LookupType { get; set; }
        public DbSet<Lookup> Lookup { get; set; }

    }
}


