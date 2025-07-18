using Godot;

namespace TheBizarreJourney.Scripts.WorldEntities;

public partial class TestEntity : WorldEntity
{
	public override string EntityName { get; protected set; } = "Test";
	
	public override void Interact(WorldEntity entity)
	{
		GD.Print(EntityName);
	}
}
