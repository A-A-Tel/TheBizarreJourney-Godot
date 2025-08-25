using Godot;

namespace TheBizarreJourney.Scripts.WorldEntities;

public abstract partial class WorldEntity : StaticBody2D
{
	protected Direction Direction;

	protected AnimationPlayer AnimPlayer;
	
	public abstract string EntityName { get; protected set; }

	public abstract void Interact(WorldEntity entity);

	public override void _Ready()
	{
		Direction = Direction.South;
		AnimPlayer = GetNode<AnimationPlayer>("Sprite/AnimationPlayer");
	}
}
