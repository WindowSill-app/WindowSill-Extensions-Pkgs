using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetIndex;

public class Resource
{
    [JsonPropertyName("@id")]
    public string? id { get; set; }

    [JsonPropertyName("@type")]
    public string? type { get; set; }
    public string? comment { get; set; }
    public string? clientVersion { get; set; }
}
