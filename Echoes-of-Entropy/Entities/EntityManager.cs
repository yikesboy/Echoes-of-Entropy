using System.Numerics;

namespace Echoes_of_Entropy.Entities;

public class EntityManager
{
    private readonly List<IGameEntity> _entities = new();
    private Player? _player;

    public void SpawnPlayer(Vector2 position, string spritePath)
    {
        var player = new Player(position, spritePath);
        _entities.Add(player);
        _player = player;
        player.SetUp();
    }

    public void SpawnEntity(IGameEntity entity)
    {
        _entities.Add(entity);
        entity.SetUp();
    }

    public void Update()
    {
        foreach (var entity in _entities) entity.Update();
    }

    public void Draw()
    {
        foreach (var entity in _entities) entity.Draw();
    }

    public void Clear()
    {
        _entities.Clear();
    }

    public Vector2? GetPlayerPosition()
    {
        return _player?.GetPosition();
    }
}