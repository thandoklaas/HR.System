using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HR.System.Infrastructure.persistance;

public sealed class LeaveDbContextFactory : IDesignTimeDbContextFactory<LeaveDbContext>
{
    public LeaveDbContext CreateDbContext(string[] args)
    {
        var environment =
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            ?? "Development";

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = @"Data Source=localhost\SQLEXPRESS;Database=LeaveManagementDb;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Command Timeout=0";
            //configuration.GetConnectionString("LeaveManagementConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Connection string 'LeaveManagementConnection' was not found.");
        }

        var optionsBuilder = new DbContextOptionsBuilder<LeaveDbContext>();

        optionsBuilder.UseSqlServer(
            connectionString,
            sql =>
            {
                sql.MigrationsAssembly(typeof(LeaveDbContext).Assembly.FullName);

                sql.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);

                sql.CommandTimeout(60);
            });

        return new LeaveDbContext(optionsBuilder.Options);
    }
}