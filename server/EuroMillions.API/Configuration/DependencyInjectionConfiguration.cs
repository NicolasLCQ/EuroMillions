namespace EuroMillions.API.Configuration;

using Application.Interfaces;
using Application.Interfaces.Infrastructure.Adapters;
using Application.Interfaces.Services;
using Application.Services;

using Infrastructure.Adapters;

using Resources;

public static class DependencyInjectionConfiguration
{
    public static void AddTransients(this IHostApplicationBuilder builder)
    {
        builder.Services.AddTransient<ICsvAdapter, CsvAdapter>();

        builder.Services.AddTransient<IDrawServices, DrawServices>();

        builder.Services.AddTransient<UploadRessource>();
    }
}