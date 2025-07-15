using Godot;

namespace TheBizarreJourney.Scripts.Misc;

public partial class AudioManager : Node
{
    private AudioStreamPlayer _menuDeselect = new();

    private AudioStreamPlayer _menuHover = new();
    private AudioStreamPlayer _menuSelect = new();
    private AudioStreamPlayer _no = new();
    private int _volume = 70;

    public override void _Ready()
    {
        AudioStreamWav menuHover = GD.Load<AudioStreamWav>("uid://ci4noconwpmu5");
        AudioStreamWav menuSelect = GD.Load<AudioStreamWav>("uid://bhq28m4rsbiy0");
        AudioStreamWav menuDeselect = GD.Load<AudioStreamWav>("uid://85c07jlpiwly");
        AudioStreamWav no = GD.Load<AudioStreamWav>("uid://bshvmi04gekqr");

        AddPlayer(_menuHover, menuHover, "MenuHover");
        AddPlayer(_menuSelect, menuSelect, "MenuSelect");
        AddPlayer(_menuDeselect, menuDeselect, "MenuDeselect");
        AddPlayer(_no, no, "No");

        SetVolume(_volume);
    }

    public int GetVolume()
    {
        return _volume;
    }

    public void SetVolume(int volume)
    {
        _volume = volume;
        if (volume == 0) AudioServer.SetBusVolumeDb(0, -80);
        else AudioServer.SetBusVolumeDb(0, Mathf.Lerp(-30f, -5f, volume / 100f));
    }

    public void PlayMenuHover()
    {
        _menuHover.Play();
    }

    public void PlayMenuSelect()
    {
        _menuSelect.Play();
    }

    public void PlayMenuDeselect()
    {
        _menuDeselect.Play();
    }

    public void PlayNo()
    {
        _no.Play();
    }

    private void AddPlayer(AudioStreamPlayer player, AudioStream stream, string name)
    {
        player.Name = name;
        player.Stream = stream;
        player.VolumeDb = 10;
        AddChild(player);
    }
}