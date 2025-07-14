using Godot;

namespace TheBizarreJourney.Scripts.Misc;

public static class MathHelper
{
    public static bool IsBetween(Vector2 value, Vector2 min, Vector2 max)
    {
        return value.X >= min.X && value.X <= max.X &&
               value.Y >= min.Y && value.Y <= max.Y;
    }
}