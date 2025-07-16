using Godot;
using TheBizarreJourney.Scripts.WorldEntities;

namespace TheBizarreJourney.Scripts.Misc;

public static class MathHelper
{
    public static bool IsVector2Between(Vector2 value, Vector2 min, Vector2 max)
    {
        return value.X >= min.X && value.X <= max.X &&
               value.Y >= min.Y && value.Y <= max.Y;
    }
    
    public static Direction GetVector2Direction(Vector2 vector)
    {
        Vector2 absolute = vector.Abs();
        
        return absolute.X > absolute.Y
            ? vector.X > 0
                ? Direction.East
                : Direction.West
            : vector.Y > 0
                ? Direction.South
                : Direction.North;
    }
}