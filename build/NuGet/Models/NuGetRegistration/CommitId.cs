using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetRegistration;

public class CommitId
{
    [JsonPropertyName("@id")]
    public string? id { get; set; }
}
