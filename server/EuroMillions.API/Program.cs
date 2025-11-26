using EuroMillions.API.Routes;

namespace EuroMillions.API;

using Application.Interfaces.Infrastructure.Adapters;
using Application.Interfaces.Infrastructure.Repositories;
using Application.Interfaces.Services;
using Application.UseCases;

using Handlers;

using Infrastructure.Adapters;
using Infrastructure.Context;
using Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;

using Resources;

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
            options.AddPolicy("AllowConsumers",
                policy =>
                {
                    policy.WithOrigins(builder.Configuration["AllowedConsumers"]!.Split(","));
                });
        });

        builder.Services.AddDbContext<EuroMillionsDbContext>(optionBuilder =>
        {
            optionBuilder.UseMySql(builder.Configuration.GetConnectionString("EuroMillionsDb"),
                ServerVersion.Parse("9.1.0-mysql"));
        });

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

        app.UseCors("AllowConsumers");
        app.UseHttpsRedirection();
        app.Run();
    }
}
