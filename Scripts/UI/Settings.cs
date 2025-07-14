using System;
using Godot;

namespace TheBizarreJourney.Scripts.UI;

public partial class Settings : Control
{
	public Node PreviousScene { get; set; }

	private HSlider _volumeSlider;
	private Label _volumeLabel;

	private CheckButton _fullscreenCheck;
	private Label _fullscreenLabel;

	private Button _exitButton;

	private Camera2D _camera;

	private void VolumeAction(double valueD)
	{
		int value = (int)valueD;

		_volumeLabel.Text = value.ToString();

		Main.AudioManager.SetVolume(value);
	}

	private void FullscreenAction()
	{
		bool fullscreen = _fullscreenCheck.ButtonPressed;
		_fullscreenLabel.Text = fullscreen ? "On" : "Off";

		DisplayServer.WindowSetMode(
			fullscreen ? DisplayServer.WindowMode.Fullscreen : DisplayServer.WindowMode.Windowed);

		if (fullscreen) Main.AudioManager.PlayMenuSelect();
		else Main.AudioManager.PlayMenuDeselect();
	}

	private void ExitAction()
	{
		SceneTree tree = GetTree();
		Window root = tree.Root;

		root.AddChild(PreviousScene);
		root.RemoveChild(this);

		tree.Paused = false;
		QueueFree();
	}

	public override void _Ready()
	{
		_volumeSlider = GetNode<HSlider>("VolumeSlider");
		_volumeLabel = GetNode<Label>("VolumeLabel");

		_volumeSlider.Value = Main.AudioManager.GetVolume();
		_volumeSlider.ValueChanged += VolumeAction;
		_volumeSlider.MouseEntered += Main.AudioManager.PlayMenuHover;

		VolumeAction(Main.AudioManager.GetVolume());


		_fullscreenCheck = GetNode<CheckButton>("FullscreenCheck");
		_fullscreenLabel = GetNode<Label>("FullscreenLabel");

		_fullscreenCheck.Pressed += FullscreenAction;
		_fullscreenCheck.MouseEntered += Main.AudioManager.PlayMenuHover;

		_fullscreenCheck.ButtonPressed = DisplayServer.WindowGetMode() == DisplayServer.WindowMode.Fullscreen;

		_exitButton = GetNode<Button>("ExitButton");

		_exitButton.Pressed += ExitAction;
		_exitButton.Pressed += Main.AudioManager.PlayMenuDeselect;
		_exitButton.MouseEntered += Main.AudioManager.PlayMenuHover;


		_camera = GetNode<Camera2D>("Camera");

		_camera.MakeCurrent();


		GetTree().Paused = true;
	}
}
