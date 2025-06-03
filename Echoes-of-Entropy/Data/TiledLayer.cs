using System.Text.Json.Serialization;

namespace Echoes_of_Entropy.Data;

public class TiledLayer
{
    [JsonPropertyName("name")] public string Name { get; set; } = "";
    [JsonPropertyName("width")] public int Width { get; set; }
    [JsonPropertyName("height")] public int Height { get; set; }
    [JsonPropertyName("data")] public List<int> Data { get; set; } = new();
}