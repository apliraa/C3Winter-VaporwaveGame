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
		// implementar código de reinicialização
		GD.Print("RESET");
	}

}
