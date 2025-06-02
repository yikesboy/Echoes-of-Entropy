using System.Numerics;
using Raylib_cs;

namespace Echoes_of_Entropy.Entities;

public class Key: IGameEntity
{
    private Vector2 _position;
    private string _labelText;
    private KeyboardKey _keyboardKey;
    private bool active;

    public Key(Vector2 position, string labelText, KeyboardKey keyboardKey)
    {
        _position = position;
        _labelText = labelText;
        _keyboardKey = keyboardKey;
    }
    
    public void SetUp()
    {
        // Nothing to do.
    }
    public void Update()
    {
        active = Raylib.IsKeyDown(_keyboardKey);
    }
    public void Draw()
    {
        {
            Raylib.DrawRectangle((int)_position.X, (int)_position.Y,50, 50, active ? Color.White : Color.Gray);
            Raylib.DrawText(_labelText, (int)_position.X + 12, (int)_position.Y + 12, 30, Color.Black);
        }
    }
}