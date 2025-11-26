using EuroMillions.Application.Interfaces.Infrastructure.Adapters;
using EuroMillions.Application.Interfaces.Infrastructure.Repositories;
using EuroMillions.Application.Interfaces.Services;

namespace EuroMillions.Application.UseCases;

public partial class Draws(ICsvAdapter csvAdapter, IDrawRepository drawRepository) : IUploadServices {}
