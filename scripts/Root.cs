using Godot;
using System;

public partial class Root : Control
{
	[Export] private int time;
	[Export] private Desktop desktop;
	
	public override void _Ready()
	{
		SignalBus.Instance.CorruptionCompleted += Reset;
		desktop.StartCorruption(time);
	}

	private void Reset()
	{
		GetTree().ChangeSceneToFile("res://scenes/TelaInicial.tscn");
		SignalBus.Instance.CorruptionCompleted -= Reset;
		GD.Print("RESET");
	}

}
