using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EzRent.Infrastructure.Context;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
        
        var connectionString = "server=localhost;uid=admin;pwd=password;database=EzRent;";
        optionsBuilder.UseMySql(connectionString, serverVersion);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}