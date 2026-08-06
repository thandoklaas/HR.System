using HR.System.Application.interfaces;
using HR.System.Application.mappings;
using HR.System.Infrastructure.persistance;
using HR.System.Infrastructure.repository;
using Microsoft.EntityFrameworkCore;
using JwtSettings = HR.System.Application.authentication.JwtSettings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.Configure<JwtSettings>(
builder.Configuration.GetSection(JwtSettings.SectionName));
//builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(cfg =>
{
    // cfg.LicenseKey = "..."; // only if you have one
}, AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<LeaveDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("LeaveManagementConnection"),
        sql =>
        {
            sql.MigrationsAssembly(typeof(LeaveDbContext).Assembly.FullName);

            sql.EnableRetryOnFailure();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
