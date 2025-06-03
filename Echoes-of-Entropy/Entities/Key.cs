using System.Numerics;
using Echoes_of_Entropy.Input;
using Echoes_of_Entropy.User_Interface;
using Raylib_cs;

namespace Echoes_of_Entropy.Entities;

public class Key: IUserInterfaceElement
{
    private readonly Vector2 _position;
    private readonly string _labelText;
    private readonly GameAction _gameAction;
    private bool _active;

    public Key(Vector2 position, string labelText, GameAction gameAction)
    {
        _position = position;
        _labelText = labelText;
        _gameAction = gameAction;
    }
    public void Update()
    {
        _active = InputManager.Instance.IsActionDown(_gameAction);
    }
    public void Draw()
    {
        {
            Raylib.DrawRectangle((int)_position.X, (int)_position.Y,50, 50, _active ? Color.White : Color.Gray);
            Raylib.DrawText(_labelText, (int)_position.X + 12, (int)_position.Y + 12, 30, Color.Black);
        }
    }
}