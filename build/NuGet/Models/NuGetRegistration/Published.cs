using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetRegistration;

public class Published
{
    [JsonPropertyName("@type")]
    public string type { get; set; }
}
