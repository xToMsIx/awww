using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using SchoolRegister.DAL.EF;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        // Ścieżka do folderu z appsettings.json (czyli SchoolRegister.Web)
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "SchoolRegister.Web");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.UseLazyLoadingProxies();

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
