using Raylib_cs;

namespace Echoes_of_Entropy.Input;

public class InputManager
{
    private static InputManager? _instance;
    public static InputManager Instance => _instance ??= new InputManager();

    private readonly Dictionary<GameAction, KeyboardKey> _keyBindings = new();

    private InputManager()
    {
        _keyBindings[GameAction.MoveUp] = KeyboardKey.W;
        _keyBindings[GameAction.MoveDown] = KeyboardKey.S;
        _keyBindings[GameAction.MoveLeft] = KeyboardKey.A;
        _keyBindings[GameAction.MoveRight] = KeyboardKey.D;
        _keyBindings[GameAction.Dodge] = KeyboardKey.Space;
    }

    public bool IsActionDown(GameAction action)
    {
        if (_keyBindings.TryGetValue(action, out var key))
        {
            return Raylib.IsKeyDown(key);
        }
        return false;
    }

    public bool IsActionPressed(GameAction action)
    {
        if (_keyBindings.TryGetValue(action, out var key))
        {
            return Raylib.IsKeyPressed(key);
        }
        return false;
    }
}