using Godot;
using TheBizarreJourney.Scripts.Misc;

namespace TheBizarreJourney.Scripts.UI;

public partial class MainMenu : Control
{
	private Button _startButton;
	private Button _settingsButton;
	private Button _quitButton;

	private void StartGame()
	{
		Window root = GetTree().Root;

		root.AddChild(GD.Load<PackedScene>("uid://c3h7ie5iyrsuu").Instantiate<TileMapLayer>());
		root.RemoveChild(this);
	}

	private void OpenSettings()
	{
		Window root = GetTree().Root;
		Settings settingsMenu = ResourceLoader.Load<PackedScene>("uid://0om27gmb1j0n").Instantiate<Settings>();

		settingsMenu.PreviousScene = this;

		root.AddChild(settingsMenu);
		root.RemoveChild(this);
	}

	private void QuitGame()
	{
		GetTree().Quit();
	}

	public override void _Ready()
	{
		_startButton = GetNode<Button>("StartButton");

		_startButton.MouseEntered += Main.AudioManager.PlayMenuHover;

		_startButton.Pressed += StartGame;
		_startButton.Pressed += Main.AudioManager.PlayMenuSelect;


		_settingsButton = GetNode<Button>("SettingsButton");

		_settingsButton.MouseEntered += Main.AudioManager.PlayMenuHover;

		_settingsButton.Pressed += OpenSettings;
		_settingsButton.Pressed += Main.AudioManager.PlayMenuSelect;


		_quitButton = GetNode<Button>("QuitButton");

		_quitButton.MouseEntered += Main.AudioManager.PlayMenuHover;

		_quitButton.Pressed += QuitGame;
		_quitButton.Pressed += Main.AudioManager.PlayMenuSelect;
	}
}
