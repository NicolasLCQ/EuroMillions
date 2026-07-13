using EuroMillions.Application.Extensions;
using EuroMillions.Application.Mappers;
using EuroMillions.Application.Models;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<DrawItemsStatisticsModel> GetStatisticsAsync()
    {
        //lorsque l'on va ajouter tous les calculs, passer par un dictionnaire de l'objet final
        //et faire un foreach et
        //recupérer tous les elements a partir des dictionnaires calculés via l'index
        List<MinimalDrawModel> draws = await drawRepository.GetMinimalDrawsAsync();
        (BallDictionary ballCounts, StarDictionary starCounts) = draws.CalculateNbTimesDraw();

        //dicoF
        //dicoF[1]["Counts"] = ballCounts[1]

        return new DrawItemsStatisticsModel
        {
            Balls = ballCounts
                .OrderBy(entry => (int)entry.Key)
                .Select(entry => entry.ToBallStatisticsModel())
                .ToList(),
            Stars = starCounts
                .OrderBy(entry => (int)entry.Key)
                .Select(entry => entry.ToStarStatisticsModel())
                .ToList()
        };
    }
}
