using EuroMillions.API.Models;
using EuroMillions.API.Ressources;
using Microsoft.AspNetCore.Mvc;

namespace EuroMillions.API.Routes;

public static class DrawsRoutes
{
    public static void AddDrawsRoutes(this WebApplication app)
    {
        app.MapPost("/api/draws/add", async ([FromServices]DrawsRessources drawsRessources,[FromBody]IEnumerable<Draw> draws) =>
        {
            await drawsRessources.AddDraws(draws);
        });
        
        app.MapGet("/api/draws", async ([FromServices]DrawsRessources drawsRessources) =>
        {
            return await drawsRessources.GetDraws();
        });
    }
}