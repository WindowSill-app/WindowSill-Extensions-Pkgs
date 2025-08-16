using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetRegistration;

public class Context
{
    [JsonPropertyName("@vocab")]
    public string? vocab { get; set; }
    public string? catalog { get; set; }
    public string? xsd { get; set; }
    public Item? items { get; set; }
    public CommitTimeStamp? commitTimeStamp { get; set; }
    public CommitId? commitId { get; set; }
    public Count? count { get; set; }
    public Parent? parent { get; set; }
    public Tags? tags { get; set; }
    public Reasons? reasons { get; set; }
    public PackageTargetFrameworks? packageTargetFrameworks { get; set; }
    public DependencyGroup? dependencyGroups { get; set; }
    public Dependencies? dependencies { get; set; }
    public PackageContent? packageContent { get; set; }
    public Published? published { get; set; }
    public Registration? registration { get; set; }
}
