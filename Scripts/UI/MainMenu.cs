using Godot;

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

        root.AddChild(GD.Load<PackedScene>("uid://c3h7ie5iyrsuu").Instantiate<TileMapLayer>());
        root.RemoveChild(this);
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