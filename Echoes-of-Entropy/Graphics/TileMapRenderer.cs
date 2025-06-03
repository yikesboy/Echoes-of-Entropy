using System.Numerics;
using System.Text.Json;
using Echoes_of_Entropy.Data;
using Raylib_cs;

namespace Echoes_of_Entropy.Graphics;

public class TileMapRenderer : IDisposable
{
    private TiledMap? _map;
    private Texture2D _tileset;
    private readonly Dictionary<int, Rectangle> _tileIdToRect = new();
    private bool _disposed;
    private float _scale = 4.0f;

    public void LoadMap(string mapPath, string tilesetPath)
    {
        if (string.IsNullOrEmpty(mapPath) || !File.Exists(mapPath))
            throw new ArgumentException("Invalid or missing map file path.", nameof(mapPath));
        if (string.IsNullOrEmpty(tilesetPath) || !File.Exists(tilesetPath))
            throw new ArgumentException("Invalid or missing tileset file path.", nameof(tilesetPath));

        _tileset = Raylib.LoadTexture(tilesetPath);
        if (_tileset.Id == 0)
            throw new InvalidOperationException("Failed to load tileset texture.");

        var jsonString = File.ReadAllText(mapPath);
        _map = JsonSerializer.Deserialize<TiledMap>(jsonString);
        if (_map == null)
            throw new InvalidOperationException("Failed to parse map JSON.");

        if (_map.Width <= 0 || _map.Height <= 0 || _map.TileWidth <= 0 || _map.TileHeight <= 0)
            throw new InvalidOperationException("Invalid map dimensions or tile size.");
        if (!_map.TileSets.Any())
            throw new InvalidOperationException("No tilesets defined in map JSON.");

        GenerateTileRects();
    }

    private void GenerateTileRects()
    {
        _tileIdToRect.Clear();
        _tileIdToRect.Add(0, new Rectangle(0, 0, 0, 0));

        const int tileSize = 16;
        const int spacing = 1;
        var tilesPerRow = _tileset.Width / (tileSize + spacing);
        var tilesPerCol = _tileset.Height / (tileSize + spacing);

        if (tilesPerRow <= 0 || tilesPerCol <= 0)
            throw new InvalidOperationException("Tileset dimensions are too small or invalid.");

        var tileIdMap = new[]
        {
            new[] { 1, 2, 3, 4, 5, 6 },
            new[] { 18, 29, 20, 21, 22, 23 }
        };

        for (var row = 0; row < tileIdMap.Length && row < tilesPerCol; row++)
        for (var col = 0; col < tileIdMap[row].Length && col < tilesPerRow; col++)
        {
            var tileId = tileIdMap[row][col];
            var rect = new Rectangle(
                col * (tileSize + spacing),
                row * (tileSize + spacing),
                tileSize,
                tileSize
            );
            _tileIdToRect[tileId] = rect;
        }
    }

    public void Draw()
    {
        if (_map == null || _disposed) return;

        foreach (var layer in _map.Layers)
        {
            //if (layer.Name == "collision") continue;
            DrawLayer(layer);
        }
    }

    private void DrawLayer(TiledLayer layer)
    {
        if (layer.Data.Count != layer.Width * layer.Height)
        {
            Console.WriteLine(
                $"Warning: Layer '{layer.Name}' data size mismatch. Expected {layer.Width * layer.Height}, got {layer.Data.Count}.");
            return;
        }

        for (var y = 0; y < layer.Height; y++)
        for (var x = 0; x < layer.Width; x++)
        {
            var index = y * layer.Width + x;
            var tileId = layer.Data[index];
            if (tileId == 0 || !_tileIdToRect.ContainsKey(tileId)) continue;

            var sourceRect = _tileIdToRect[tileId];
            var destPos = new Vector2(x * _map.TileWidth * _scale, y * _map.TileHeight * _scale);
            var destRect = new Rectangle(
                destPos.X,
                destPos.Y,
                _map.TileWidth * _scale,
                _map.TileHeight * _scale
            );
            Raylib.DrawTexturePro(_tileset, sourceRect, destRect, new Vector2(0, 0), 0.0f, Color.White);
        }
    }

    public bool IsTileSolid(int x, int y)
    {
        if (_map == null || _disposed) return false;

        var collisionLayer = _map.Layers.FirstOrDefault(l => l.Name == "collision");
        if (collisionLayer == null)
        {
            Console.WriteLine("Warning: No collision layer found.");
            return false;
        }

        if (x < 0 || x >= collisionLayer.Width || y < 0 || y >= collisionLayer.Height)
            return true;

        var index = y * collisionLayer.Width + x;
        if (index >= collisionLayer.Data.Count)
        {
            Console.WriteLine($"Warning: Invalid collision layer index ({index}) for position ({x}, {y}).");
            return false;
        }

        return collisionLayer.Data[index] != 0;
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            Raylib.UnloadTexture(_tileset);
            _disposed = true;
        }
    }
}