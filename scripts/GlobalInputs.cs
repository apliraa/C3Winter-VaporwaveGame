using Godot;
using System;

public partial class GlobalInputs : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("ui_cancel")){
			GetTree().Quit();
		}
	}
}
