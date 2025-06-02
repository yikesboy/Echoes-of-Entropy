using System.Numerics;
using Raylib_cs;

namespace Echoes_of_Entropy.Entities;

public class Player : IGameEntity
{
    private const float Speed = 300f;
    private Vector2 _position;
    private readonly string _path;
    private Texture2D _texture;

    public Player(Vector2 position, string path)
    {
        _position = position;
        _path = path;
    }

    public void SetUp()
    {
        _texture = Raylib.LoadTexture(_path);
    }

    public void Update()
    {
        var dt = Raylib.GetFrameTime();
        if (Raylib.IsKeyDown(KeyboardKey.W)) {_position.Y -= Speed * dt;}
        if (Raylib.IsKeyDown(KeyboardKey.A)) {_position.X -= Speed * dt;}
        if (Raylib.IsKeyDown(KeyboardKey.S)) {_position.Y += Speed * dt;}
        if (Raylib.IsKeyDown(KeyboardKey.D)) {_position.X += Speed * dt;}
    }

    public void Draw()
    {
        Raylib.DrawTextureEx(_texture, _position, 0, 0.5f, Color.White);
    }
}