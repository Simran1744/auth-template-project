using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using AuthDemoApplication.Data;
using AuthDemoApplication.DTOs.Mods;
using AuthDemoApplication.Models;
using AuthDemoApplication.Options;
using AuthDemoApplication.Repositories;
using AuthDemoApplication.Repositories.Interfaces;
using AuthDemoApplication.Seeders;
using AuthDemoApplication.Services;
using AuthDemoApplication.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters
            .Add(new JsonStringEnumConverter());
    });
    

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection(JwtOptions.SectionName));

var jwtOptions = builder.Configuration
    .GetSection(JwtOptions.SectionName)
    .Get<JwtOptions>() ?? throw new InvalidOperationException("JWT configuration is missing.");

if (string.IsNullOrWhiteSpace(jwtOptions.Secret) || jwtOptions.Secret.Length < 32)
{
    throw new InvalidOperationException("JWT secret must be at least 32 characters long.");
}

builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularClient", policy =>
    {
        var allowedOrigins = builder.Configuration
            .GetSection("Cors:AllowedOrigins")
            .Get<string[]>() ?? [];

        policy
            .WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); //required for cookies -> HttpOnly Cookie-based JWT Authentication */
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = false;
});

builder.Services
    .AddIdentityCore<ApplicationUser>(options =>
    {
        options.Password.RequiredLength = 8;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = false;

        options.User.RequireUniqueEmail = true;

        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = true;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = !builder.Environment.IsDevelopment();
        options.SaveToken = false;
        
        //  Read JWT Token
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var token = context.Request.Cookies["token"];
                if (!string.IsNullOrEmpty(token))
                {
                    context.Token = token;
                }
                return Task.CompletedTask;
            }
        };

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,

            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtOptions.Secret)),

            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromMinutes(1),

            NameClaimType = System.Security.Claims.ClaimTypes.Name,
            RoleClaimType = System.Security.Claims.ClaimTypes.Role
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<IAssetRepository, AssetRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IAssetService, AssetService>();

// This binds the "NexusMods" section of your secrets/appsettings to the NexusOptions class
builder.Services.Configure<NexusOptions>(builder.Configuration.GetSection("NexusMods"));

builder.Services.AddHttpClient<NexusModsSeeder>(client =>
{
    client.BaseAddress = new Uri("https://api.nexusmods.com/v1/");
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("AngularClient");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (args.Contains("--seed-games"))
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();
    await GameSeeder.SeedAsync(context);
    return; // exit after seeding, don't start the web server
}

// Fill the database with some mods for from NexusMods for testing purposes
if (args.Contains("--seed-mods"))
{
    using var scope = app.Services.CreateScope();
    var myService = scope.ServiceProvider.GetRequiredService<NexusModsSeeder>();
    //List<NexusModsJsonResponse>? trendingMods = await myService.GetTrendingModsAsync();
    
    bool success = await myService.GetTrendingModsAsync();
    
    Console.WriteLine(success);
    
    // 4. Use the data!
     /*if (trendingMods != null && trendingMods.Count > 0)
     {
         Console.WriteLine($"\nSuccessfully found {trendingMods.Count} trending mods:\n");

         foreach (var mod in trendingMods)
         {
             // Print the mod name and who uploaded it from the nested User class
             Console.WriteLine($"- {mod.name} (Version: {mod.version})"); 
             Console.WriteLine($"  Uploaded by: {mod.user?.name ?? "Unknown"}");
             Console.WriteLine($"  Downloads: {mod.mod_downloads:N0}");
             Console.WriteLine($"  Picture Url: {mod.picture_url ?? "Unknown"}");
             Console.WriteLine(new string('-', 40));
        }
     }
     else
     {
        Console.WriteLine("No trending mods found or response was empty.");
     }*/

     return;
}

app.Run();
