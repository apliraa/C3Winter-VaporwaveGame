using Godot;
using System;

public partial class TelaInicial : Control
{
	private VideoStreamPlayer vsp;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		vsp =GetNode<VideoStreamPlayer>("VideoStreamPlayer");
		vsp.Finished += _on_video_stream_player_finished;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_button_pressed(){
		vsp.Play();
		
	}
	
	public void _on_video_stream_player_finished(){
		GetTree().ChangeSceneToFile("res://scenes/root.tscn");
	}
}
