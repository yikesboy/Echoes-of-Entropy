using System.Numerics;
using Echoes_of_Entropy.Entities;
using Raylib_cs;

namespace Echoes_of_Entropy;
class Game
{
    private readonly List<IGameEntity> _entities = new();
    public Game()
    {
        var player = new Player(new Vector2(200, 200));
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
        const int screen = 1;
        int screenHeight = Raylib.GetMonitorHeight(screen);
        Console.WriteLine(screenHeight);
        int screenWidth = Raylib.GetMonitorWidth(screen);
        Console.WriteLine(screenWidth);
        int screenRefreshRate = Raylib.GetMonitorRefreshRate(screen);
        Console.WriteLine(screenRefreshRate);
        
        Raylib.InitWindow(800, 600, gameName);
        Raylib.SetTargetFPS(screenRefreshRate);
    }

    private void Loop()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.DarkGray);
            Raylib.DrawText("Echoes of Entropy.", 20, 20, 20, Color.RayWhite);

            foreach (var entity in _entities)
            {
               entity.Update(); 
               entity.Draw(); 
            }
            
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}