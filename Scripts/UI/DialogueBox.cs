using System;
using System.Collections;
using System.Collections.Generic;
using Godot;

namespace TheBizarreJourney.Scripts.UI;

public partial class DialogueBox : Control
{
	private Queue<string> Dialogue { get; set; }

	private RichTextLabel _text;
	
	private Timer _printInterval;

	private DialogueBox()
	{
	}

	public override void _Ready()
	{
		_text = GetNode<RichTextLabel>("Texture/Text");
		GetTree().Paused = true;
		
		_text.Text = Dialogue.Dequeue();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("INTERACT"))
		{
			string result;
			if (Dialogue.TryDequeue(out result))
			{
				_text.Text = result;
			}
			else
			{
				GetTree().Paused = false;
				QueueFree();
			}
		}
	}

	public static DialogueBox New(string[] dialogue)
	{
		DialogueBox box = GD.Load<PackedScene>("uid://b6hx3h20t84wc").Instantiate<DialogueBox>();
		box.Dialogue = new Queue<string>(dialogue);
		
		return box;
	}
}
