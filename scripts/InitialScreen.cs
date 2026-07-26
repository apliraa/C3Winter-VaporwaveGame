using Godot;
using System;

public partial class InitialScreen : VideoStreamPlayer
{
	public void _on_finished(){
		GetTree().ChangeSceneToFile("res://scenes/TelaInicial.tscn");
	}
}
