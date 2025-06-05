using Godot;

namespace TheBizarreJourney.Scripts.UI;

public partial class Settings : Control
{
    private HSlider _volumeSlider;
    private Label _volumeLabel;

    private CheckButton _fullscreenCheck;
    private Label _fullscreenLabel;

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

    public override void _Ready()
    {
        _volumeSlider = GetNode<HSlider>("VolumeSlider");
        _volumeLabel = GetNode<Label>("VolumeLabel");

        _volumeSlider.ValueChanged += VolumeAction;
        VolumeAction(_volumeSlider.Value);


        _fullscreenCheck = GetNode<CheckButton>("FullscreenCheck");
        _fullscreenLabel = GetNode<Label>("FullscreenLabel");

        _fullscreenCheck.Pressed += FullscreenAction;
        _fullscreenCheck.ButtonPressed = DisplayServer.WindowGetMode() == DisplayServer.WindowMode.Fullscreen;
        FullscreenAction();
    }
}