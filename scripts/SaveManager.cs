using Godot;
using System;
using System.Collections.Generic;

public partial class SaveManager : Node
{
	public static SaveManager Instance{ get; private set;}
	public string notePadData = "";
	public List<string> lastDisplayedApps;
	
	public override void _Ready()
	{
		Instance = this;
	}
	
	
	
}
