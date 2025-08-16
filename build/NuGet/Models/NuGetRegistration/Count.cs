using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetRegistration;

public class Count
{
    [JsonPropertyName("@id")]
    public string id { get; set; }
}
