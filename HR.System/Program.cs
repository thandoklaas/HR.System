using HR.System.Application.feature.employees.commands;
using HR.System.Application.interfaces;
using HR.System.Infrastructure.authentication;
using HR.System.Infrastructure.identity;
using HR.System.Infrastructure.persistance;
using HR.System.Infrastructure.repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;  
using JwtSettings = HR.System.Application.authentication.JwtSettings;

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------------
// Controllers
// --------------------------------------------------

builder.Services.AddControllers();


// --------------------------------------------------
// Database
// --------------------------------------------------

builder.Services.AddDbContext<LeaveDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("LeaveManagementConnection"),
        sql =>
        {
            sql.MigrationsAssembly(
                typeof(LeaveDbContext).Assembly.FullName);

            // sql.EnableRetryOnFailure();
        });
});


// --------------------------------------------------
// Identity
// --------------------------------------------------

builder.Services
    .AddIdentityCore<ApplicationUser>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 8;

        options.User.RequireUniqueEmail = true;

        options.SignIn.RequireConfirmedEmail = false;
    })
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<LeaveDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();


//--------------------------------------------------
//JWT Authentication
//--------------------------------------------------
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme =
            JwtBearerDefaults.AuthenticationScheme;

        options.DefaultChallengeScheme =
            JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        var jwtSettings =
            builder.Configuration
                .GetSection(JwtSettings.SectionName)
                .Get<JwtSettings>()
                ?? throw new InvalidOperationException(
                    "JwtSettings configuration is missing.");

        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtSettings.Issuer,

                ValidateAudience = true,
                ValidAudience = jwtSettings.Audience,

                ValidateLifetime = true,

                ValidateIssuerSigningKey = true,

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            jwtSettings.SecretKey)),

                ClockSkew = TimeSpan.Zero
            };
    });


builder.Services.AddAuthorization();

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection(JwtSettings.SectionName));

builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IdentitySeeder>();

// --------------------------------------------------
// MediatR
// --------------------------------------------------

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(
        typeof(CreateEmployeeCommandHandler).Assembly);
});


// --------------------------------------------------
// Application services
// --------------------------------------------------

builder.Services.AddScoped<IAuthenticationAdapter, LocalAuthenticationAdapter>();


// --------------------------------------------------
// Repository / Unit of Work
// --------------------------------------------------

builder.Services.AddScoped(
    typeof(IRepository<>),
    typeof(EntityFrameworkRepository<>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// --------------------------------------------------
// AutoMapper
// --------------------------------------------------

builder.Services.AddAutoMapper(
    cfg => { },
    AppDomain.CurrentDomain.GetAssemblies());


// --------------------------------------------------
// HTTP Context
// --------------------------------------------------

builder.Services.AddHttpContextAccessor();

// --------------------------------------------------
// Swagger
// --------------------------------------------------

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


// --------------------------------------------------
// Development
// --------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapGet("/", () => Results.Redirect("/swagger"));
}


// --------------------------------------------------
// Database seeding
// --------------------------------------------------

using (var scope = app.Services.CreateScope())
{

    var context = scope.ServiceProvider
        .GetRequiredService<LeaveDbContext>();

    var identitySeeder =
    scope.ServiceProvider
        .GetRequiredService<IdentitySeeder>();

    await identitySeeder.SeedAsync();


    var businessSeeder = new BusinessDataSeeder(context);

    await businessSeeder.SeedAsync();


}


// --------------------------------------------------
// HTTP Pipeline
// --------------------------------------------------

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();