using EuroMillions.API.Entities;
using EuroMillions.API.Models;
using EuroMillions.Application.Contracts.Repositories;
using EuroMillions.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EuroMillions.API.Ressources;

public class DrawsRessources(DrawsServices drawsServices)
{
    public async Task<IResult> AddDraws(IEnumerable<Draw>? draws)
    {
        if(draws == null)
        {
            return Results.BadRequest("No draws to add");
        }
        
        await drawsServices.AddDraws(draws.Select(d => d.ToEntity()));
        return Results.Ok();
    }

    public async Task<IResult> GetDraws()
    {
        return Results.Ok((await drawsServices.GetDraws()).Select(Draw.FromEntity));
    }
}