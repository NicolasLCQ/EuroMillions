using EuroMillions.Application.Interfaces.Infrastructure.Adapters;
using EuroMillions.Application.Interfaces.Infrastructure.Repositories;
using EuroMillions.Application.Interfaces.UseCases;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases(ICsvAdapter csvAdapter, IDrawRepository drawRepository) : IDrawUseCases {}
