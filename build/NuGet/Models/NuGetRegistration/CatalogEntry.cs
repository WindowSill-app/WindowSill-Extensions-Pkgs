using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetRegistration;

public class CatalogEntry
{
    [JsonPropertyName("@id")]
    public string? id { get; set; }

    [JsonPropertyName("@type")]
    public string? type { get; set; }

    [JsonPropertyName("id")]
    public string? packageid { get; set; }
    public string? authors { get; set; }
    public string? description { get; set; }
    public string? iconUrl { get; set; }
    public string? language { get; set; }
    public string? licenseExpression { get; set; }
    public string? licenseUrl { get; set; }
    public bool listed { get; set; }
    public string? minClientVersion { get; set; }
    public string? packageContent { get; set; }
    public string? projectUrl { get; set; }
    public DateTime published { get; set; }
    public bool requireLicenseAcceptance { get; set; }
    public string? summary { get; set; }
    public List<string>? tags { get; set; }
    public string? title { get; set; }
    public string? version { get; set; }
    public List<DependencyGroup>? dependencyGroups { get; set; }
    public string? readmeUrl { get; set; }
}
