using Models;

using NuGet;
using NuGet.Models.NuGetRegistration;

using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main() => Execute<Build>(x => x.GenerateManifest);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    private const string WindowSillExtensionTag = "windowsill-extension";
    private static readonly string[] ExtensionAllowedCategories = ["Productivity", "AI", "Development", "Media", "Utilities", "Integration"];

    AbsolutePath OutputDirectory => RootDirectory / "output";
    AbsolutePath ExtensionsFile => RootDirectory / "extensions.json";

    Target Clean => _ => _
        .Before(GenerateManifest)
        .Executes(() =>
        {
            if (Directory.Exists(OutputDirectory))
                Directory.Delete(OutputDirectory, true);
            Directory.CreateDirectory(OutputDirectory);
            Serilog.Log.Information("Cleared output folder...");
        });

    Target GenerateManifest => _ => _
        .DependsOn(Clean)
        .Executes(async () =>
        {
            await GenerateExtensionManifestAsync();
        });

    private async Task GenerateExtensionManifestAsync()
    {
        Serilog.Log.Information("Generating extension manifest...");

        // Ensure extensions.json exists
        if (!File.Exists(ExtensionsFile))
        {
            Serilog.Log.Warning("extensions.json not found. Creating empty file.");
            await File.WriteAllTextAsync(ExtensionsFile, "[]");
        }

        // Read approved extensions
        ExtensionEntry[] approvedExtensions;
        try
        {
            string extensionsJson = await File.ReadAllTextAsync(ExtensionsFile);
            approvedExtensions
                = JsonSerializer.Deserialize<ExtensionEntry[]>(
                    extensionsJson,
                    JsonSerializerOptions.Web)
                ?? Array.Empty<ExtensionEntry>();
        }
        catch (Exception ex)
        {
            Serilog.Log.Error(ex, "Failed to read {File}: {Message}", Path.GetFileName(ExtensionsFile), ex.Message);
            Assert.Fail(string.Empty);
            return;
        }

        Serilog.Log.Information("Found {Count} extensions", approvedExtensions.Length);

        List<ManifestEntry> manifests = new List<ManifestEntry>();
        await TreatEachExtensionsAsync(manifests, approvedExtensions);

        Directory.CreateDirectory(OutputDirectory);
        AbsolutePath manifestsPath = OutputDirectory / "manifest.json";

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        string manifestsJson = JsonSerializer.Serialize(manifests, options);
        await File.WriteAllTextAsync(manifestsPath, manifestsJson);

        Serilog.Log.Information("Generated manifest with {Count} extensions at {Path}", manifests.Count, manifestsPath);
    }

    private void ValidateExtensionEntry(ExtensionEntry extension)
    {
        if (string.IsNullOrWhiteSpace(extension.PackageId))
        {
            Serilog.Log.Error("Extension has no PackageId defined");
            Assert.Fail(string.Empty);
        }

        if (!ExtensionAllowedCategories.ContainsAnyOrdinalIgnoreCase(extension.Category))
        {
            Serilog.Log.Error("Extension {PackageId} has no valid Category defined. Category should be one of the following: {Categories}", extension.PackageId, string.Join(", ", ExtensionAllowedCategories));
            Assert.Fail(string.Empty);
        }
    }

    private async Task TreatEachExtensionsAsync(List<ManifestEntry> manifests, ExtensionEntry[] approvedExtensions)
    {
        using NuGetService nugetService = new NuGetService();

        foreach (ExtensionEntry extension in approvedExtensions)
        {
            try
            {
                Serilog.Log.Information("Processing extension: {PackageId}", extension.PackageId);

                ValidateExtensionEntry(extension);

                // Get package metadata from NuGet
                CatalogEntry? catalogEntry = await nugetService.GetPackageMetadataAsync(extension.PackageId!);
                if (catalogEntry == null)
                {
                    Serilog.Log.Error("Could not find package metadata for {PackageId}", extension.PackageId);
                    Assert.Fail(string.Empty);
                    return;
                }

                // Validate it's actually an extension
                bool isValid = nugetService.ValidateExtensionPackage(catalogEntry, WindowSillExtensionTag);
                if (!isValid)
                {
                    Serilog.Log.Error("Package {PackageId} does not appear to be a valid extension. Ensure the NuGet package has a description, authors, a tag {WindowSillExtensionTag} and has a dependency on {API}.", catalogEntry.packageid, WindowSillExtensionTag, "WindowSill.API");
                    Assert.Fail(string.Empty);
                }

                manifests.Add(
                    new ManifestEntry
                    {
                        PackageId = catalogEntry.packageid!,
                        IconUrl = catalogEntry.iconUrl,
                        Category = extension.Category!
                    });
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Failed to process extension {PackageId}: {Message}", extension.PackageId, ex.Message);
                Assert.Fail(string.Empty);
            }
        }
    }
}
