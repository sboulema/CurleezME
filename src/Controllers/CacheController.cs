using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CurleezME.Controllers;

[Route("[controller]")]
public class CacheController(IMemoryCache memoryCache) : Controller
{
    [HttpGet("[action]")]
    public IActionResult Clear()
    {
        memoryCache.Remove("beers");

        return RedirectToAction("Index", "Home");
    }
}
