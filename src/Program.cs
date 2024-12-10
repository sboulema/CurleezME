using CurleezME.Repositories;
using CurleezME.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddControllersWithViews();

builder.Services
	.AddScoped<IBeerService, BeerService>()
	.AddScoped<IUntappdRepository, UntappdRepository>();

builder.Services
	.AddHttpClient("Untappd", httpClient =>
	{
		httpClient.BaseAddress = new Uri("https://api.untappd.com");
	})
	.RemoveAllLoggers();

var app = builder.Build();

app.UseHsts();

app.UseHttpsRedirection();

app.UseRouting();

app.MapStaticAssets();

app.MapControllers();

app.Run();
