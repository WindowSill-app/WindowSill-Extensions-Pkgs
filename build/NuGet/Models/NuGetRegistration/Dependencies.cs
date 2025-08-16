using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetRegistration;

public class Dependencies
{
    [JsonPropertyName("@id")]
    public string id { get; set; }

    [JsonPropertyName("@container")]
    public string container { get; set; }

    [JsonPropertyName("@type")]
    public string type { get; set; }
    public string range { get; set; }
    public string registration { get; set; }
}
