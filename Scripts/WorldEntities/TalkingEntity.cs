namespace TheBizarreJourney.Scripts.WorldEntities;

public partial class TalkingEntity : WorldEntity
{
	public override string EntityName { get; protected set; }

	private string[] _dialogue;

	public override void _Ready()
	{
		EntityName = GetMeta("Name").AsString();
		_dialogue = GetMeta("Dialogue").AsStringArray();
	}

	public override void Interact(WorldEntity entity)
	{
		Main.PlayerEntity.InitiateDialogue(_dialogue);
	}
}
