namespace EuroMillions.API.Configuration;

public static class CorsConfiguration
{
    public static void DefineCorsPolicies(this IHostApplicationBuilder builder) =>
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowConsumers",
                policy =>
                {
                    policy.WithOrigins(builder.Configuration["AllowedConsumers"]!.Split(","));
                });
        });

    public static void UseCorsPolicies(this IApplicationBuilder app) => app.UseCors("AllowConsumers");
}
