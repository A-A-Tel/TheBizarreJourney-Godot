using System.Linq;
using Godot;
using TheBizarreJourney.Scripts.Misc;
using TheBizarreJourney.Scripts.UI;

namespace TheBizarreJourney.Scripts;

public partial class Main : Node
{
    public static readonly AudioManager AudioManager = new();

    public override void _Ready()
    {
        Window root = GetTree().Root;

        root.CallDeferred(Node.MethodName.RemoveChild, this);
        QueueFree();

        AudioManager.Name = "AudioManager";

        root.CallDeferred(Node.MethodName.AddChild, AudioManager);
        root.CallDeferred(Node.MethodName.AddChild, GD.Load<PackedScene>("uid://b7lx5afapaokt").Instantiate());
    }
}