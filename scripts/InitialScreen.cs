using Godot;
using System;

public partial class InitialScreen : VideoStreamPlayer
{
	public void _on_finished(){
		GetTree().ChangeSceneToFile("res://scenes/TelaInicial.tscn");
	}
	
	public override void _Process(double delta){
		if(Input.IsActionJustPressed("ui_accept")||Input.IsActionJustPressed("ui_right")){
		 	GetTree().ChangeSceneToFile("res://scenes/TelaInicial.tscn");
		}
	}
	
}
