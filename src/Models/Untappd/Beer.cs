using System.Text.Json.Serialization;

namespace CurleezME.Models.Untappd
{
    public class Beer
    {
        [JsonPropertyName("beer_label")]
        public string LabelUrl { get; set; } = string.Empty;

        [JsonPropertyName("beer_slug")]
        public string Slug { get; set; } = string.Empty;

        [JsonPropertyName("bid")]
        public int Id { get; set; }

        [JsonPropertyName("beer_name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("beer_style")]
        public string Style { get; set; } = string.Empty;

        [JsonPropertyName("beer_abv")]
        public double? ABV { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedDate { get; set; } = string.Empty;
    }
}
