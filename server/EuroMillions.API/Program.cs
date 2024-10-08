using EuroMillions.API.Configuration;
using EuroMillions.API.Routes;

namespace EuroMillions.API;

using Resources;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddTransient<UploadRessource>();

        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDevelopmentConfiguration();
        }

        app.UseUploadRoutes();

        app.UseHttpsRedirection();
        app.Run();
    }
}
