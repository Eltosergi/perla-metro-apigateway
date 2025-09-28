using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Ocelot.json", optional: false, reloadOnChange: true);


builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Debug);
builder.Logging.AddConsole();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://perla-metro-userservice.onrender.com",
            ValidAudience = "https://perla-metro-userservice.onrender.com",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("EstaEsUnaContraseñaSuperlargaEsperoqueFuncioneEstaWeaXdUnSaludo7"))
        };
    });


builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    if (context.User?.Identity?.IsAuthenticated ?? false)
    {
        Console.WriteLine("Claims del usuario:");
        foreach (var claim in context.User.Claims)
        {
            Console.WriteLine($"{claim.Type} = {claim.Value}");
        }
    }
    await next();
});


await app.UseOcelot();

app.Run();
