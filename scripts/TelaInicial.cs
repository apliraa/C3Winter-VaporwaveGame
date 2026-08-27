using Godot;
using System;

public partial class TelaInicial : Control
{
	private AnimationPlayer turnON;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		turnON = GetNode<AnimationPlayer>("turnOnPC");
		
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_button_pressed(){
		turnON.Play("turnOnPC");
		
	}
	
	public void ligarPC(){
		GetTree().ChangeSceneToFile("res://scenes/root.tscn");
	}
}
