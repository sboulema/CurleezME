using System.Text.Json.Serialization;

namespace CurleezME.Models.Untappd;

public class CheckinUser
{
    [JsonPropertyName("user_avatar")]
    public string AvatarURL { get; set; } = string.Empty;

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = string.Empty;
}
