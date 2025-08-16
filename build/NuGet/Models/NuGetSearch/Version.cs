using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetSearch;

public class Version
{
    public string version { get; set; }
    public int downloads { get; set; }

    [JsonPropertyName("@id")]
    public string id { get; set; }
}
