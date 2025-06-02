using System.Numerics;
using Echoes_of_Entropy.Entities;
using Raylib_cs;

namespace Echoes_of_Entropy;

class Game
{
    private readonly List<IGameEntity> _entities = new();

    public Game()
    {
        var player = new Player(new Vector2(200, 200),
            "../../../Assets/image.png");
        _entities.Add(player);
        var wKey = new Key(new Vector2(500, 450), "W", KeyboardKey.W);
        _entities.Add(wKey);
        var sKey = new Key(new Vector2(500, 510), "S", KeyboardKey.S);
        _entities.Add(sKey);
        var aKey = new Key(new Vector2(440, 510), "A", KeyboardKey.A);
        _entities.Add(aKey);
        var dKey = new Key(new Vector2(560, 510), "D", KeyboardKey.D);
        _entities.Add(dKey);
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
            
            Raylib.DrawFPS(100, 500);
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}