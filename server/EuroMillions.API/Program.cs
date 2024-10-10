using EuroMillions.API.Configuration;
using EuroMillions.API.Routes;

namespace EuroMillions.API;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.AddConfiguration();
        builder.DefineCorsPolicies();
        builder.AddTransients();

        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDevelopmentConfiguration();
        }

        app.UseUploadRoutes();
        app.UseCorsPolicies();
        app.UseHttpsRedirection();
        app.Run();
    }
}
