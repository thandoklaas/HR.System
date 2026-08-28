using HR.System.Application.interfaces;
using HR.System.Infrastructure.authentication;
using HR.System.Infrastructure.identity;
using HR.System.Infrastructure.persistance;
using HR.System.Infrastructure.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.System.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<LeaveDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("LeaveManagementConnection")));

        services
            .AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;

                options.Password.RequiredLength = 8;

                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = false;
            })
            .AddEntityFrameworkStores<LeaveDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<JwtSettings>(
            configuration.GetSection(JwtSettings.SectionName));

        //services.AddScoped<IJwtService, JwtService>();

        services.AddScoped<IDatabaseTransaction, EntityDatabaseTransaction>();

        services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // repositories
        // identity
        // authentication
        // caching
        // messaging

        return services;
    }
}