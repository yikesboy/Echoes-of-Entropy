using System.Numerics;
using Echoes_of_Entropy.Entities;
using Echoes_of_Entropy.Input;

namespace Echoes_of_Entropy.User_Interface;

public class UIManager
{
    private readonly List<IUserInterfaceElement> _uiElements = new();

    public void Initialize()
    {
        _uiElements.Add(new Key(new Vector2(500, 450), "W", GameAction.MoveUp));
        _uiElements.Add(new Key(new Vector2(500, 510), "S", GameAction.MoveDown));
        _uiElements.Add(new Key(new Vector2(440, 510), "A", GameAction.MoveLeft));
        _uiElements.Add(new Key(new Vector2(560, 510), "D", GameAction.MoveRight));
        _uiElements.Add(new Key(new Vector2(620, 510), "SPACE", GameAction.Dodge));
    }

    public void Update()
    {
        foreach (var uiElement in _uiElements)
        {
           uiElement.Update(); 
        }
    }
    
    public void Draw()
    {
        foreach (var uiElement in _uiElements)
        {
            uiElement.Draw(); 
        }
    }
}