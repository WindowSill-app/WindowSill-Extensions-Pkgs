using Microsoft.Extensions.DependencyModel;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetRegistration;

public class DependencyGroup
{
    [JsonPropertyName("@id")]
    public string id { get; set; }

    [JsonPropertyName("@type")]
    public string type { get; set; }
    public string targetFramework { get; set; }
    public List<Dependency> dependencies { get; set; }

    [JsonPropertyName("@container")]
    public string container { get; set; }
}
