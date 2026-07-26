using Godot;
using System;

public partial class SaveManager : Node
{
	public static SaveManager Instance{ get; private set;}
	public string notePadData = "";
	
	public override void _Ready()
	{
		Instance = this;
	}
	
	
	
}
