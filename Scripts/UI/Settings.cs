using System;
using Godot;
using TheBizarreJourney.Scripts.Misc;
using TheBizarreJourney.Scripts;

namespace TheBizarreJourney.Scripts.UI;

public partial class Settings : Control
{
	public Node PreviousScene { get; set; }

	private AudioManager _audioManager;

	private HSlider _volumeSlider;
	private Label _volumeLabel;

	private CheckButton _fullscreenCheck;
	private Label _fullscreenLabel;

	private Button _exitButton;

	private void VolumeAction(double valueD)
	{
		int value = (int)valueD;

		_volumeLabel.Text = (value).ToString();
		_audioManager.SetVolume(value);
	}

	private void FullscreenAction()
	{
		bool fullscreen = _fullscreenCheck.ButtonPressed;
		_fullscreenLabel.Text = fullscreen ? "On" : "Off";

		DisplayServer.WindowSetMode(
			fullscreen ? DisplayServer.WindowMode.Fullscreen : DisplayServer.WindowMode.Windowed);
		if (fullscreen) _audioManager.PlayMenuSelect();
	}

	private void ExitAction()
	{
		Window root = GetTree().Root;

		root.AddChild(PreviousScene);
		root.RemoveChild(this);
		QueueFree();
	}

	public override void _Ready()
	{
		_audioManager = GetTree().Root.GetChild<AudioManager>(0);

		_volumeSlider = GetNode<HSlider>("VolumeSlider");
		_volumeLabel = GetNode<Label>("VolumeLabel");

		_volumeSlider.Value = _audioManager.GetVolume();
		_volumeSlider.ValueChanged += VolumeAction;
		_volumeSlider.MouseEntered += _audioManager.PlayMenuHover;

		VolumeAction(_audioManager.GetVolume());


		_fullscreenCheck = GetNode<CheckButton>("FullscreenCheck");
		_fullscreenLabel = GetNode<Label>("FullscreenLabel");

		_fullscreenCheck.Pressed += FullscreenAction;
		_fullscreenCheck.MouseEntered += _audioManager.PlayMenuHover;

		_fullscreenCheck.ButtonPressed = DisplayServer.WindowGetMode() == DisplayServer.WindowMode.Fullscreen;
		FullscreenAction();


		_exitButton = GetNode<Button>("ExitButton");

		_exitButton.Pressed += ExitAction;
		_exitButton.MouseEntered += _audioManager.PlayMenuHover;
	}
}
