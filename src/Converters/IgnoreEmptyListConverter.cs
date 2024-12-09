using System.Text.Json.Serialization;
using System.Text.Json;
using CurleezME.Models.Untappd;

namespace CurleezME.Converters;

public class IgnoreEmptyListConverter : JsonConverter<CheckinVenue>
{
    public override CheckinVenue? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            return JsonSerializer
                .Deserialize<List<CheckinVenue>>(ref reader, options)?
                .FirstOrDefault();
        }

        return (CheckinVenue?)JsonSerializer.Deserialize(ref reader, typeToConvert, options);
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckinVenue value,
        JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}