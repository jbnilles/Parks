using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace Parks.Models
{
  public class DesignTimeDbContextFactory
  {
    public class FactoryContextFactory : IDesignTimeDbContextFactory<ParksContext>
    {

      ParksContext IDesignTimeDbContextFactory<ParksContext>.CreateDbContext(string[] args)
      {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<ParksContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseMySql(connectionString);

        return new ParksContext(builder.Options);
      }
    }
  }
}