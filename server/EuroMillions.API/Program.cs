using EuroMillions.API.Configuration;
using EuroMillions.API.Routes;

namespace EuroMillions.API;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.DefineCorsPolicies();

        builder.AddTransients();

        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //Routes
        app.UseUploadRoutes();

        app.UseCorsPolicies();
        app.UseHttpsRedirection();
        app.Run();
    }
}
