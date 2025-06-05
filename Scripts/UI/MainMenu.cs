using Godot;

namespace TheBizarreJourney.Scripts.UI;

public partial class MainMenu : Control
{
	private Button _startButton;
	private Button _settingsButton;

	private void StartGame()
	{
		GD.Print("Game started");
	}

	private void OpenSettings()
	{
		
	}

	public override void _Ready()
	{
		_startButton = GetNode<Button>("StartButton");
		_settingsButton = GetNode<Button>("SettingsButton");
		
		_startButton.Pressed += StartGame;
		_settingsButton.Pressed += OpenSettings;
	}
}
