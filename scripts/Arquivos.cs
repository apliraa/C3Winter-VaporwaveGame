using Godot;
using System;

public partial class Arquivos : Button
{
	[Export] private PackedScene windowTeste;
	
	public void _on_pressed(){
		Node window = windowTeste.Instantiate();
		Owner.AddChild(window);
	}
	
}
