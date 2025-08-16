using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetRegistration;

public class Tags
{
    [JsonPropertyName("@id")]
    public string? id { get; set; }

    [JsonPropertyName("@container")]
    public string? container { get; set; }
}
