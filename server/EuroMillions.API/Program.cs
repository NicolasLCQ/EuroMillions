using EuroMillions.API.Handlers;
using EuroMillions.API.Resources;
using EuroMillions.API.Routes;
using EuroMillions.Application.Interfaces.Infrastructure.Adapters;
using EuroMillions.Application.Interfaces.Infrastructure.Repositories;
using EuroMillions.Application.Interfaces.UseCases;
using EuroMillions.Application.UseCases;
using EuroMillions.Infrastructure.Adapters;
using EuroMillions.Infrastructure.Context;
using EuroMillions.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;

namespace EuroMillions.API;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddExceptionHandler<ApplicationExceptionHandler>();
        builder.Services.AddExceptionHandler<UnHandledExceptionHandler>();

        builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowFrontend",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000") // Autorise spécifiquement votre frontend
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    }
                );
            }
        );

        string dbPath = Path.Combine(AppContext.BaseDirectory, "Externals", "EuroMillions.db");
        string connectionString = $"Data Source={dbPath}";

        builder.Services.AddDbContext<EuroMillionsDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlite(connectionString);
            }
        );

        builder.Services.AddTransient<IDrawRepository, DrawRepository>();
        builder.Services.AddTransient<ICsvAdapter, CsvAdapter>();
        builder.Services.AddTransient<IDrawUseCases, DrawUseCases>();
        builder.Services.AddTransient<DrawResources>();

        WebApplication app = builder.Build();
        app.UseExceptionHandler(_ => {});

        app.UseCors("AllowFrontend");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //Routes
        app.UseDrawRoutes();

        app.UseHttpsRedirection();
        app.Run();
    }
}
