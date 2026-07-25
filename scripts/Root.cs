using Godot;
using System;

public partial class Root : Control
{
	[Export] private int time;
	[Export] private Desktop desktop;
	
	public override void _Ready()
	{
		desktop.StartCorruption(time);
	}


}
