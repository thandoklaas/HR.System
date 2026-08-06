using HR.System.Application.authentication;
using HR.System.Application.interfaces;
using HR.System.Infrastructure.persistance;
using HRSystem.Infrastructure.Authentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.Configure<JwtSettings>(
builder.Configuration.GetSection(JwtSettings.SectionName));

builder.Services.AddScoped<IJwtService, JwtService>();
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
