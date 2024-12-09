using System.Text.Json.Serialization;
using CurleezME.Converters;

namespace CurleezME.Models.Untappd;

public class Checkin
{
    public CheckinUser? User { get; set; }

    public Beer? Beer { get; set; }

    [JsonConverter(typeof(IgnoreEmptyListConverter))]
    public CheckinVenue? Venue { get; set; }

    [JsonPropertyName("checkin_comment")]
    public string Comment { get; set; } = string.Empty;

    [JsonPropertyName("rating_score")]
    public double? Rating { get; set; }
}
