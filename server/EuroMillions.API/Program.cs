using EuroMillions.API.Context;
using EuroMillions.API.Ressources;
using EuroMillions.API.Routes;
using EuroMillions.Application.Contracts.Repositories;
using EuroMillions.Application.Services;
using EuroMillions.Gateway.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EuroMillions.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        AddServices(builder);

        var app = builder.Build();
        ConfigureApp(app);
        app.AddDrawsRoutes();
        app.Run();
    }
    
    #region snippet_AddServices
    private static void AddServices(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddDbContext<EuroMillionsStudyDbContext>(options =>
        {
            options
                .UseMySql(builder.Configuration.GetConnectionString("EuroMillionsStudyDbContext"),
                    new MySqlServerVersion(new Version(8, 0, 26)))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .LogTo(Console.WriteLine);
        });
        
        builder.Services.AddScoped<IDrawsRepository, DrawsRepository>();
        builder.Services.AddScoped<DrawsRessources>();
        builder.Services.AddScoped<DrawsServices>();
    }
    #endregion
    
    #region snippet_ConfigureApp
    private static void ConfigureApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
    }
    #endregion
}