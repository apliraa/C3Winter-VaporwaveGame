using Godot;
using System;

public partial class InitialScreen : Control
{
	private AnimationPlayer switcher;
	private bool waitingInput = false;

	public override void _Ready()
	{
		switcher = GetNode<AnimationPlayer>("Switcher");
		
		switcher.Play("logoCutscene");
	}

	public void PausarParaInput()
{
	switcher.Pause(); 
	waitingInput = true;
}

	public override void _Input(InputEvent @event)
	{
		if (waitingInput && @event.IsActionPressed("aceitar"))
		{
			waitingInput = false;
			
			switcher.Play(); 
		}
	}
	
	public void changeToGame(){
		GetTree().ChangeSceneToFile("res://scenes/TelaInicial.tscn");
	}
	
}
