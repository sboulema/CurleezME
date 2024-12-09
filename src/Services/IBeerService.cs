using CurleezME.Models.Untappd;

namespace CurleezME.Services;

public interface IBeerService
{
    Task<List<Beer>> GetBeers();

    Task<List<Checkin>> GetCheckins();
}