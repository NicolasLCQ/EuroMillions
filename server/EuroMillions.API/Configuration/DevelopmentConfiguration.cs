namespace EuroMillions.API.Configuration;

public static class DevelopmentConfiguration
{
    public static void UseDevelopmentConfiguration(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}
