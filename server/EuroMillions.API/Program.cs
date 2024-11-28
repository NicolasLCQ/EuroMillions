using EuroMillions.API.Configuration;
using EuroMillions.API.Routes;

namespace EuroMillions.API;

using Infrastructure.Context;

using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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
            // optionBuilder.UseMySql(builder.Configuration.GetConnectionString("EuroMillionsDb"), ServerVersion.Parse("9.1.0-mysql"));
            optionBuilder.UseMySql("server=localhost;port=3002;user=root;password=root;database=DB_EUROMILLIONS", ServerVersion.Parse("9.1.0-mysql"));
        });

        builder.AddTransients();

        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //Routes
        app.UseUploadRoutes();

        app.UseCors("AllowConsumers");
        app.UseHttpsRedirection();
        app.Run();
    }
}
