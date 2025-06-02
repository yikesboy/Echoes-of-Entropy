using System.Numerics;
using Echoes_of_Entropy.Input;
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
        var input = InputManager.Instance;
        
        if (input.IsActionDown(GameAction.MoveUp)) {_position.Y -= Speed * dt;}
        if (input.IsActionDown(GameAction.MoveLeft)) {_position.X -= Speed * dt;}
        if (input.IsActionDown(GameAction.MoveDown)) {_position.Y += Speed * dt;}
        if (input.IsActionDown(GameAction.MoveRight)) {_position.X += Speed * dt;}
    }

    public void Draw()
    {
        Raylib.DrawTextureEx(_texture, _position, 0, 0.5f, Color.White);
    }
}