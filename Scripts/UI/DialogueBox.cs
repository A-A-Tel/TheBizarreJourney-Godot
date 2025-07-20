using Godot;

namespace TheBizarreJourney.Scripts.UI;

public partial class DialogueBox : Control
{
    private string[] Dialogue { get; set; }

    private RichTextLabel _text;
    
    private Timer _printInterval;

    private DialogueBox()
    {
    }

    public override void _Ready()
    {
        
    }

    public static DialogueBox New(string[] dialogue)
    {
        DialogueBox box = new();
        box.Dialogue = dialogue;
        return box;
    }
}