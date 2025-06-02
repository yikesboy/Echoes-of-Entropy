using System.Numerics;
using Echoes_of_Entropy.Input;
using Raylib_cs;

namespace Echoes_of_Entropy.Entities;

public class Player : IGameEntity
{
    private const float Speed = 300f;
    private const float DodgeRotationSpeed = 720f;
    private Vector2 _position;
    private readonly string _path;
    private Texture2D _texture;
    
    private float _currentRotation = 0f;
    private bool _isDodging = false;
    private float _dodgeRotation = 0f;

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

        if (input.IsActionPressed(GameAction.Dodge))
        {
            _isDodging = true;
            _dodgeRotation = 0f;
        }
        
        if (_isDodging)
        {
            _dodgeRotation += DodgeRotationSpeed * dt;
            if (_dodgeRotation >= 360f)
            {
                _isDodging = false;
                _dodgeRotation = 0f;
            }
        }
        
        _currentRotation = _isDodging ? _dodgeRotation : 0f;
    }

    public void Draw()
    {
        Raylib.DrawTextureEx(_texture, _position, _currentRotation, 0.5f, Color.White);
    }
}