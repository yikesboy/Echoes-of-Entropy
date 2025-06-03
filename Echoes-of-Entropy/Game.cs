using System.Numerics;
using Echoes_of_Entropy.Entities;
using Echoes_of_Entropy.Input;
using Echoes_of_Entropy.User_Interface;
using Raylib_cs;

namespace Echoes_of_Entropy;

class Game
{
    private readonly List<IGameEntity> _entities = new();
    private readonly UIManager _uiManager = new();

    public Game()
    {
        var player = new Player(new Vector2(200, 200),
            "../../../Assets/image.png");
        _entities.Add(player);
    }

    static void Main()
    {
        var game = new Game();
        game.Setup();
        game.Loop();
    }

    private void Setup()
    {
        const String gameName = "Echoes of Entropy";
        const int screen = 0;
        var screenHeight = Raylib.GetMonitorHeight(screen);
        Console.WriteLine(screenHeight);
        var screenWidth = Raylib.GetMonitorWidth(screen);
        Console.WriteLine(screenWidth);
        var screenRefreshRate = Raylib.GetMonitorRefreshRate(screen);
        Console.WriteLine(screenRefreshRate);

        Raylib.InitWindow(800, 600, gameName);
        Raylib.SetTargetFPS(165);

        foreach (var entity in _entities)
        {
            entity.SetUp();
        }
        
        _uiManager.Initialize();
    }

    private void Loop()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.SkyBlue);
            Raylib.DrawText("Echoes of Entropy.", 20, 20, 20, Color.RayWhite);

            foreach (var entity in _entities)
            {
                entity.Update();
                entity.Draw();
            }
            
            _uiManager.Update();
            _uiManager.Draw();
            Raylib.DrawFPS(100, 500);
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}