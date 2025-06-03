using System.Text.Json.Serialization;

namespace Echoes_of_Entropy.Data;

public class TiledTileset
{
    [JsonPropertyName("firstgid")] public int FirstGid { get; set; }
    [JsonPropertyName("source")] public string Source { get; set; } = "";
}