using Godot;

namespace TheBizarreJourney.Scripts.Misc;

public partial class AudioManager : Node
{
    private int _volume = 70;

    private AudioStreamPlayer _menuHover = new();
    private AudioStreamPlayer _menuSelect = new();
    private AudioStreamPlayer _menuDeselect = new();
    
    public override void _Ready()
    {
        AudioStreamWav menuHover = GD.Load<AudioStreamWav>("uid://ci4noconwpmu5");
        AudioStreamWav menuSelect = GD.Load<AudioStreamWav>("uid://bhq28m4rsbiy0");
        
        AddPlayer(_menuHover, menuHover, "MenuHover");
        AddPlayer(_menuSelect, menuSelect, "MenuSelect");
        
        SetVolume(_volume);
    }

    public int GetVolume()
    {

        return _volume;
    }

    public void SetVolume(int volume)
    {
        _volume = volume;
        AudioServer.SetBusVolumeDb(0, Mathf.Lerp(-80f, 24f, volume / 100f));
    }

    public void PlayMenuHover()
    {
        _menuHover.Play();
    }

    public void PlayMenuSelect()
    {
        _menuSelect.Play();
    }

    private void AddPlayer(AudioStreamPlayer player, AudioStream stream, string name)
    {
        player.Name = name;
        player.Stream = stream;
        player.VolumeDb = 10;
        AddChild(player);
    }
}