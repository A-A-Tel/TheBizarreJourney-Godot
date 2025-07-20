using Godot;
using TheBizarreJourney.Scripts.WorldEntities;

namespace TheBizarreJourney.Scripts.UI;

public partial class MainMenu : Control
{
	private Camera2D _camera;
	private Button _quitButton;
	private Button _settingsButton;
	private Button _startButton;

	private void StartGame()
	{
		Window root = GetTree().Root;

		TileMapLayer room = GD.Load<PackedScene>("uid://c3h7ie5iyrsuu").Instantiate<TileMapLayer>();
		PlayerEntity player = GD.Load<PackedScene>("uid://b8cmtqrfvtct4").Instantiate<PlayerEntity>();
		
		room.AddChild(player);
		root.AddChild(room);
		
		Main.PlayerEntity = player;
		
		root.RemoveChild(this);
		QueueFree();
	}

	private void OpenSettings()
	{
		Main.SettingsMenu.PauseGame(_camera);
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


		_camera = GetNode<Camera2D>("Camera");
	}
}
