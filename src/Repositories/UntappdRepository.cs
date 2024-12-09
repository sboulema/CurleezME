using CurleezME.Models.Untappd;

namespace CurleezME.Repositories;

public class UntappdRepository(
    IHttpClientFactory httpClientFactory,
    IConfiguration configuration) : IUntappdRepository
{
    public async Task<Beer?> GetBeer(int beerId)
    {
        var client = httpClientFactory.CreateClient("Untappd");

        var response = await client.GetFromJsonAsync<BeerResponse>(
            $"/v4/beer/info/{beerId}" +
            $"?client_id={configuration["ClientId"]}" +
            $"&client_secret={configuration["ClientSecret"]}" +
            "&compact=true");

        return response?.Response?.Beer;
    }

    public async Task<List<Checkin>> GetCheckins()
    {
        var client = httpClientFactory.CreateClient("Untappd");

        var response = await client.GetFromJsonAsync<CheckinsResponse>(
            $"/v4/brewery/checkins/236502" +
            $"?client_id={configuration["ClientId"]}" +
            $"&client_secret={configuration["ClientSecret"]}");

        return response?.Response?.Checkins?.Items ?? [];
    }
}
