using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetRegistration;

public class PackageContent
{
    [JsonPropertyName("@type")]
    public string type { get; set; }
}
