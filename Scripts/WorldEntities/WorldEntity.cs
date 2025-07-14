using Godot;

namespace TheBizarreJourney.Scripts.WorldEntities;

public abstract partial class WorldEntity : StaticBody2D
{
    public abstract string EntityName { get; protected set; }

    public abstract void Interact(WorldEntity entity);
}