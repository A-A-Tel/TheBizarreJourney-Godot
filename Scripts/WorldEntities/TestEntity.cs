using Godot;
using TheBizarreJourney.Scripts.UI;

namespace TheBizarreJourney.Scripts.WorldEntities;

public partial class TestEntity : WorldEntity
{
	public override string EntityName { get; protected set; } = "Test";
	
	public override void Interact(WorldEntity entity)
	{
		Main.PlayerEntity.Camera.AddChild(DialogueBox.New(["Hello there!", "Test 2"]));
	}
}
