using Microsoft.AspNetCore.Mvc;
using CurleezME.Models.ViewModels;
using CurleezME.Services;

namespace CurleezME.Controllers;

[Route("")]
public class HomeController(IBeerService beerService) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View(new IndexViewModel
        {
            Beers = await beerService.GetBeers(),
            Checkins = await beerService.GetCheckins(),
        });
    }
}
