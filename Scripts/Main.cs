using System.Linq;
using Godot;
using TheBizarreJourney.Scripts.Misc;
using TheBizarreJourney.Scripts.UI;

namespace TheBizarreJourney.Scripts;

public partial class Main : Node
{
    public override void _Ready()
    {
        QueueFree();
        Window window = GetTree().Root;

        AudioManager audioManager = new();
        audioManager.Name = "AudioManager";
        
        window.CallDeferred(Node.MethodName.AddChild, audioManager);
        window.CallDeferred(Node.MethodName.AddChild, GD.Load<PackedScene>("uid://b7lx5afapaokt").Instantiate());
    }

    
#nullable enable
    
    public static T? GetChildByName<T>(Node parent, string name) where T : Node
    {
        foreach (Node node in parent.GetChildren())
        {
            if (node.Name == name && node is T typedNode)
                return typedNode;
        }

        return null;
    }
}