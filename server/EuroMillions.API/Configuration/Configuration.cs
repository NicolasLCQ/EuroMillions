namespace EuroMillions.API.Configuration;

using Resources;

public static class Configuration
{
    public static void AddConfiguration(this IHostApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    public static void UseDevelopmentConfiguration(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    public static void AddTransients(this IHostApplicationBuilder builder) => builder.Services.AddTransient<UploadRessource>();
}
