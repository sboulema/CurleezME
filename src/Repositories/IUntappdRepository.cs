using CurleezME.Models.Untappd;

namespace CurleezME.Repositories;

public interface IUntappdRepository
{
    Task<Beer?> GetBeer(int beerId);

    Task<List<Checkin>> GetCheckins();
}