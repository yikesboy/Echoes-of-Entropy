using System.Text.Json.Serialization;

namespace Echoes_of_Entropy.Data;

public class TiledMap
{
    [JsonPropertyName("width")] public int Width { get; set; }
    [JsonPropertyName("height")] public int Height { get; set; }
    [JsonPropertyName("tilewidth")] public int TileWidth { get; set; }
    [JsonPropertyName("tileheight")] public int TileHeight { get; set; }
    [JsonPropertyName("layers")] public List<TiledLayer> Layers { get; set; } = new();
    [JsonPropertyName("tilesets")] public List<TiledTileset> TileSets { get; set; } = new();
}