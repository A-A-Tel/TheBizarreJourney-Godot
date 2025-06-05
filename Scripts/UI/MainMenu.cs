using Godot;

namespace TheBizarreJourney.Scripts.UI;

public partial class MainMenu : Control
{
	private Button _startButton;

	private void StartGame()
	{
		GD.Print("Game started");
	}

	public override void _Ready()
	{
		_startButton = GetNode<Button>("StartButton");
		_startButton.Pressed += StartGame;
	}
}
