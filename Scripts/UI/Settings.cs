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
	
	private AudioStreamPlayer _hoverAudio;

	private void VolumeAction(double value)
	{
		_volumeLabel.Text = ((int)value).ToString();
	}

	private void FullscreenAction()
	{
		bool fullscreen = _fullscreenCheck.ButtonPressed;
		_fullscreenLabel.Text = fullscreen ? "On" : "Off";
		
		DisplayServer.WindowSetMode(fullscreen ? DisplayServer.WindowMode.Fullscreen : DisplayServer.WindowMode.Windowed);
	}

	private void ExitAction()
	{
		Window root = GetTree().Root;
		
		root.AddChild(PreviousScene);
		root.RemoveChild(this);
		QueueFree();
	}

	private void HoverAction()
	{
		_hoverAudio.Play();
	}

	public override void _Ready()
	{
		_volumeSlider = GetNode<HSlider>("VolumeSlider");
		_volumeLabel = GetNode<Label>("VolumeLabel");
		
		_volumeSlider.ValueChanged += VolumeAction;
		_volumeSlider.MouseEntered += HoverAction;
		
		VolumeAction(_volumeSlider.Value);


		_fullscreenCheck = GetNode<CheckButton>("FullscreenCheck");
		_fullscreenLabel = GetNode<Label>("FullscreenLabel");

		_fullscreenCheck.Pressed += FullscreenAction;
		_fullscreenCheck.MouseEntered += HoverAction;
		
		_fullscreenCheck.ButtonPressed = DisplayServer.WindowGetMode() == DisplayServer.WindowMode.Fullscreen;
		FullscreenAction();
		
		
		_exitButton = GetNode<Button>("ExitButton");
		
		_exitButton.Pressed += ExitAction;
		_exitButton.MouseEntered += HoverAction;
		
		
		_hoverAudio = GetNode<AudioStreamPlayer>("HoverAudio");
	}
}
