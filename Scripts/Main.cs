using Godot;
using TheBizarreJourney.Scripts.Misc;
using TheBizarreJourney.Scripts.UI;

namespace TheBizarreJourney.Scripts;

public partial class Main : Node
{
    public static readonly AudioManager AudioManager = new();
    public static readonly Settings SettingsMenu = GD.Load<PackedScene>("uid://0om27gmb1j0n").Instantiate<Settings>();

    public override void _Ready()
    {
        Window root = GetTree().Root;

        root.CallDeferred(Node.MethodName.RemoveChild, this);
        QueueFree();

        AudioManager.Name = "AudioManager";
        SettingsMenu.Name = "SettingsMenu";

        root.CallDeferred(Node.MethodName.AddChild, AudioManager);
        root.CallDeferred(Node.MethodName.AddChild, SettingsMenu);
        root.CallDeferred(Node.MethodName.AddChild, GD.Load<PackedScene>("uid://b7lx5afapaokt").Instantiate());
    }
}