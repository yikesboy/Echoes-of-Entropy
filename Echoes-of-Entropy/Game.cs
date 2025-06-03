using System.Numerics;
using Echoes_of_Entropy.Entities;
using Echoes_of_Entropy.Input;
using Echoes_of_Entropy.User_Interface;
using Raylib_cs;

namespace Echoes_of_Entropy;

class Game
{
    private readonly UIManager _uiManager = new();
    private readonly EntityManager _entityManager = new();

    public Game()
    {
        
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

        Raylib.InitWindow(1600, 1200, gameName);
        Raylib.SetTargetFPS(165);

        _entityManager.SpawnPlayer(new Vector2(200, 200), "../../../Assets/image.png");
                
        _uiManager.Initialize();
    }

    private void Loop()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.SkyBlue);
            Raylib.DrawText("Echoes of Entropy.", 20, 20, 20, Color.RayWhite);

            _entityManager.Update();
            _uiManager.Update();
            
            _entityManager.Draw();
            _uiManager.Draw();
            
            Raylib.DrawFPS(100, 500);
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}