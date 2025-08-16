namespace Models;

public record ManifestEntry
{
    public required string PackageId { get; init; }

    public required string IconUrl { get; init; }

    public required string Category { get; init; }
}
