using System.Text.Json.Serialization;

namespace CurleezME.Models.Untappd;

public class CheckinVenue
{
    [JsonPropertyName("venue_name")]
    public string Name { get; set; } = string.Empty;
}
