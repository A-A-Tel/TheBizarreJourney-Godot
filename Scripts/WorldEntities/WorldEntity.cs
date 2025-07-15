using Godot;

namespace TheBizarreJourney.Scripts.WorldEntities;

public abstract partial class WorldEntity : StaticBody2D
{
    protected Direction _direction;
    
    public abstract string EntityName { get; protected set; }

    public abstract void Interact(WorldEntity entity);

    public override void _Ready()
    {
        _direction = Direction.South;
    }
}