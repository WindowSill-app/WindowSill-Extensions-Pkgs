using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NuGet.Models.NuGetRegistration;

public class NuGetRegistrationResponse
{
    [JsonPropertyName("@id")]
    public string id { get; set; }

    [JsonPropertyName("@type")]
    public List<string> type { get; set; }
    public string commitId { get; set; }
    public DateTime commitTimeStamp { get; set; }
    public int count { get; set; }
    public List<Item> items { get; set; }

    [JsonPropertyName("@context")]
    public Context context { get; set; }
}
