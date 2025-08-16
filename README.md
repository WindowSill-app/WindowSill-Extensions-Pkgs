# WindowSill Extensions Manifest

This repository manages approved extensions for WindowSill using a GitHub-based approval system.

## How to publish a new extension for WindowSill

1. **Extension authors** publish their WindowSill extensions as NuGet packages to nuget.org
2. **Extension authors** submit a PR to add their package to `extensions.json`.
   This file needs 2 information:
   - `packageId`: The NuGet package ID
   - `Category`: The category of the extension, which should be one of the following:
     - `Productivity`
     - `AI`
     - `Development`
     - `Media`
     - `Utilities`
     - `Integration`
3. **Maintainers** review and approve the PR once the CI checks pass.
4. **Once merged**, the extension will be available on WindowSill website within a day.

# How to update an existing extension

1. **Extension authors** publish a new version of their NuGet package to nuget.org.
1. WindowSill website will automatically detect the new version and update the extension catalog within a day.