using System.Numerics;
using Raylib_cs;

namespace Echoes_of_Entropy.Entities;

public class Player(Vector2 position) : IGameEntity
{
    private Vector2 _position = position;
    private const float Speed = 200f;

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
        Raylib.DrawRectangle((int)_position.X, (int)_position.Y, 100, 200, Color.Purple);
    }
}