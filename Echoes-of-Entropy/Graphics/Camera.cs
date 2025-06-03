using System.Numerics;
using Raylib_cs;

namespace Echoes_of_Entropy.Graphics;

public class Camera
{
    private Camera2D _camera2D;
    private Vector2 _targetPosition;
    private float _targetZoom;
    private float _zoomSpeed = 2.0f;
    private float _minZoom = 0.1f;
    private float _maxZoom = 4.0f;

    public Camera(Vector2 screenSize, Vector2 targetPosition, float initialZoom = 1.0f)
    {
        _camera2D = new Camera2D(screenSize / 2, targetPosition, 0.0f, initialZoom);
        _targetPosition = targetPosition;
        _targetZoom = initialZoom;
    }

    public void Update(Vector2 targetPosition, float dt)
    {
        _targetPosition = targetPosition;
        _camera2D.Target = Vector2.Lerp(_camera2D.Target, _targetPosition, 10.0f * dt);

        _camera2D.Zoom = MathHelper.Lerp(_camera2D.Zoom, _targetZoom, _zoomSpeed * dt);
    }

    public void SetZoom(float zoom)
    {
        _targetZoom = Math.Clamp(zoom, _minZoom, _maxZoom);
    }

    public void AdjustZoom(float delta)
    {
        _targetZoom = Math.Clamp(_targetZoom + delta, _minZoom, _maxZoom);
    }

    public Camera2D GetCamera2D()
    {
        return _camera2D;
    }

    public float GetZoom()
    {
        return _camera2D.Zoom;
    }

    public Vector2 ScreenToWorld(Vector2 screenPos)
    {
        return Raylib.GetScreenToWorld2D(screenPos, _camera2D);
    }

    public Vector2 WorldToScreen(Vector2 worldPos)
    {
        return Raylib.GetWorldToScreen2D(worldPos, _camera2D);
    }
}

public static class MathHelper
{
    public static float Lerp(float start, float end, float amount)
    {
        return start + (end - start) * amount;
    }
}