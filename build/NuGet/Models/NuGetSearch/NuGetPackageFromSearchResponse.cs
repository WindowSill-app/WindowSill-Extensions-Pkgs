using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetSearch;

public class NuGetPackageFromSearchResponse
{
    [JsonPropertyName("@id")]
    public string? @id { get; set; }

    [JsonPropertyName("@type")]
    public string? @type { get; set; }

    [JsonPropertyName("id")]
    public string? packageid { get; set; }
    public string? registration { get; set; }
    public string? version { get; set; }
    public string? description { get; set; }
    public string? summary { get; set; }
    public string? title { get; set; }
    public string? iconUrl { get; set; }
    public string? licenseUrl { get; set; }
    public string? projectUrl { get; set; }
    public List<string>? tags { get; set; }
    public List<string>? authors { get; set; }
    public List<string>? owners { get; set; }
    public long totalDownloads { get; set; }
    public bool verified { get; set; }
    public List<PackageType>? packageTypes { get; set; }
    public List<Version>? versions { get; set; }
    public List<object>? vulnerabilities { get; set; }
    public Deprecation? deprecation { get; set; }
}
