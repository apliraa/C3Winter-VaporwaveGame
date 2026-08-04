using Godot;
using System;

public partial class Arquivos : TextureButton
{

	[Export] private PackedScene windowTeste;
	//[Export] private Label appName;
	//
	//[Export(PropertyHint.MultilineText)] 
	//public string AppNameRoot = "appName";

	

	private bool selected;

	public override void _Ready()
	{
		SignalBus.Instance.AppSelected += Unselect;
		//appName.Text = AppNameRoot;
	}

	public void _on_pressed()
	{
		if (selected)
		{
			Node window = windowTeste.Instantiate();
			Owner.AddChild(window);
		} else
		{
			SignalBus.Instance.EmitSignal(SignalBus.SignalName.AppSelected);
		}

		selected = !selected;
	}

	public void Unselect() { if (selected) selected = false; }
	
	
}
