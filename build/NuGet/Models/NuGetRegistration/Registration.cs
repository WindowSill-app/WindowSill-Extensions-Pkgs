using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetRegistration;

public class Registration
{
    [JsonPropertyName("@type")]
    public string? type { get; set; }
}
