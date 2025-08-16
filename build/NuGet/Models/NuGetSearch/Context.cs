using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetSearch;

public class Context
{
    [JsonPropertyName("@vocab")]
    public string vocab { get; set; }

    [JsonPropertyName("@base")]
    public string @base { get; set; }
}
