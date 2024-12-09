using System.Text.Json;
using CurleezME.Models.Untappd;
using CurleezME.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace CurleezME.Services;

public class BeerService(
    IUntappdRepository untappdRepository,
    IMemoryCache memoryCache) : IBeerService
{
    public async Task<List<Beer>> GetBeers()
    {
        var beerIds = GetBeerIds();

        var beers = memoryCache.Get<List<Beer>>("beers") ?? [];

        var missingBeerId = beerIds
            .Except(beers.Select(beer => beer.Id))
            .FirstOrDefault();

        var beer = await untappdRepository.GetBeer(missingBeerId);

        if (beer == null)
        {
            return beers;
        }

        beers.Add(beer);

        memoryCache.Set("beers", beers);

        return beers;
    }

    public async Task<List<Checkin>> GetCheckins()
        => await untappdRepository.GetCheckins();

    private static List<int> GetBeerIds()
        => JsonSerializer.Deserialize<List<int>>(File.ReadAllText("Files/beerlist.json")) ?? [];
}
