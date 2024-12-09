using CurleezME.Models.Untappd;

namespace CurleezME.Models.ViewModels;

public class IndexViewModel
{
    public List<Beer> Beers { get; set; } = [];

    public List<Checkin> Checkins { get; set; } = [];
}
