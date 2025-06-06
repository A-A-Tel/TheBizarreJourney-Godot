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
		Window root = GetTree().Root;
		Settings settingsMenu = ResourceLoader.Load<PackedScene>("uid://0om27gmb1j0n").Instantiate<Settings>();

		settingsMenu.PreviousScene = this;

		root.AddChild(settingsMenu);
		root.RemoveChild(this);
	}

	public override void _Ready()
	{
		_startButton = GetNode<Button>("StartButton");
		
		_startButton.Pressed += StartGame;
		

		_settingsButton = GetNode<Button>("SettingsButton");
		
		_settingsButton.Pressed += OpenSettings;
	}
}
