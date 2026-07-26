using Godot;
using System;

public partial class NotePadSave : NewWindow
{
	[Export] TextEdit textEdit;
	public override void _on_close_button_pressed()
	{
		
		CallDeferred("free");
	}

	public override void _Ready()
	{
		textEdit.Text = SaveManager.Instance.notePadData;
		base._Ready();
	}
	
	public override void _Process(double delta){
		if (draging)
			GlobalPosition = initWindowPosit + GetGlobalMousePosition() - initMousePosit;
		SaveManager.Instance.notePadData = textEdit.Text;
	}
}
