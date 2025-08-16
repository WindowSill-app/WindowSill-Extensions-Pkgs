using System;
using System.Collections.Generic;

using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetRegistration;

public class Item
{
    [JsonPropertyName("@id")]
    public string id { get; set; }

    [JsonPropertyName("@type")]
    public string type { get; set; }
    public string commitId { get; set; }
    public DateTime commitTimeStamp { get; set; }
    public int count { get; set; }
    public List<Item> items { get; set; }
    public string parent { get; set; }
    public string lower { get; set; }
    public string upper { get; set; }
    public CatalogEntry catalogEntry { get; set; }
    public string packageContent { get; set; }
    public string registration { get; set; }

    [JsonPropertyName("@container")]
    public string container { get; set; }
}
