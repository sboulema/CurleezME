using CurleezME.Models.Untappd;

namespace CurleezME.Repositories;

public class UntappdRepository(
	IHttpClientFactory httpClientFactory,
	IConfiguration configuration,
	ILogger<UntappdRepository> logger) : IUntappdRepository
{
	public async Task<Beer?> GetBeer(int beerId)
	{
		var client = httpClientFactory.CreateClient("Untappd");

		try
		{
			var response = await client.GetFromJsonAsync<BeerResponse>(
				$"/v4/beer/info/{beerId}" +
				$"?client_id={configuration["ClientId"]}" +
				$"&client_secret={configuration["ClientSecret"]}" +
				"&compact=true");

			return response?.Response?.Beer;
		}
		catch (Exception e)
		{
			logger.LogCritical(e, $"Exception while getting beer '{beerId}'");
		}

		return null;
	}

	public async Task<List<Checkin>> GetCheckins()
	{
		var client = httpClientFactory.CreateClient("Untappd");

		try
		{
			var response = await client.GetFromJsonAsync<CheckinsResponse>(
			$"/v4/brewery/checkins/236502" +
			$"?client_id={configuration["CLIENTID"]}" +
			$"&client_secret={configuration["CLIENTSECRET"]}");

			return response?.Response?.Checkins?.Items ?? [];
		}
		catch (Exception e)
		{
			logger.LogWarning(e, "Exception while getting checkins");
		}

		return [];
	}
}
