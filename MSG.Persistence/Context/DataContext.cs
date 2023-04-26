using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MSG.Domain.Entities;

namespace MSG.Persistence.Context;

public class DataContext : DbContext
{
    public DataContext() { }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("Sqlite");
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}