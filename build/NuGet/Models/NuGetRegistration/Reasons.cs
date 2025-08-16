using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetRegistration;

public class Reasons
{
    [JsonPropertyName("@container")]
    public string? container { get; set; }
}
