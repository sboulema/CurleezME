using System.Text.Json.Serialization;

namespace CurleezME.Models.Untappd;

public class BeerList
{
    public List<Beer> Items { get; set; } = [];
}
