using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetIndex;

public class NuGetIndexResponse
{
    public string version { get; set; }
    public List<Resource> resources { get; set; }

    [JsonPropertyName("@context")]
    public Context context { get; set; }
}
