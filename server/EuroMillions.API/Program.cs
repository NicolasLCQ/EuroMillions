using EuroMillions.API.Handlers;
using EuroMillions.API.Resources;
using EuroMillions.API.Routes;
using EuroMillions.Application.Interfaces.Infrastructure.Adapters;
using EuroMillions.Application.Interfaces.Infrastructure.Repositories;
using EuroMillions.Application.Interfaces.Services;
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

        string connectionString = "Data Source=Externals/EuroMillions.db";

        builder.Services.AddDbContext<EuroMillionsDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlite(connectionString);
            }
        );

        builder.Services.AddTransient<IDrawRepository, DrawRepository>();
        builder.Services.AddTransient<ICsvAdapter, CsvAdapter>();
        builder.Services.AddTransient<IUploadServices, Draws>();
        builder.Services.AddTransient<UploadRessource>();

        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseExceptionHandler(_ => {});

        //Routes
        app.UseUploadRoutes();

        app.UseHttpsRedirection();
        app.Run();
    }
}
