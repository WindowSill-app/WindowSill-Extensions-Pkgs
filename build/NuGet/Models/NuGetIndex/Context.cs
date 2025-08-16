using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetIndex;

public class Context
{
    [JsonPropertyName("@vocab")]
    public string vocab { get; set; }
    public string comment { get; set; }
}
