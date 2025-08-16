using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetRegistration;

public class Parent
{
    [JsonPropertyName("@id")]
    public string? id { get; set; }

    [JsonPropertyName("@type")]
    public string? type { get; set; }
}
