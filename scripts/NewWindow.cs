using Godot;
using System;

public partial class NewWindow : Control
{

	private Vector2 initMousePosit;
	private Vector2 initWindowPosit;

	private bool draging;

	public override void _Process(double delta)
	{
		if (draging)
			GlobalPosition = initWindowPosit + GetGlobalMousePosition() - initMousePosit;
		
	}
	public void _on_close_button_pressed(){
		CallDeferred("free");
		
	}

	public void _on_bar_button_down()
	{
		draging = true;
	
		if (initMousePosit == Vector2.Zero)
		{
			initMousePosit = GetGlobalMousePosition();
			initWindowPosit = GlobalPosition;
		}

	}

	public void _on_bar_button_up()
	{
		draging = false;
		initMousePosit = Vector2.Zero;
	}
	
}
