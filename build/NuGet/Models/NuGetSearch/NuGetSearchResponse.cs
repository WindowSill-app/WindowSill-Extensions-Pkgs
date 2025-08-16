using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetSearch;

public class NuGetSearchResponse
{
    [JsonPropertyName("@context")]
    public Context context { get; set; }
    public int totalHits { get; set; }
    public List<NuGetPackageFromSearchResponse> data { get; set; }
}
