using Godot;
using System;

public partial class NotePadSave : NewWindow
{
	[Export] TextEdit textEdit;
	public override void _on_close_button_pressed()
	{
		SaveManager.Instance.notePadData = textEdit.Text;
		CallDeferred("free");
	}

	public override void _Ready()
	{
		textEdit.Text = SaveManager.Instance.notePadData;
		base._Ready();
	}
}
