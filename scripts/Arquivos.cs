using Godot;
using System;

public partial class Arquivos : Button
{
	[Export] private PackedScene windowTeste;
	
	
	public override void _Ready()
	{
		
	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	public void _on_pressed(){
		Node window = windowTeste.Instantiate();
		GetParent().AddChild(window);
		
	}
	
}
