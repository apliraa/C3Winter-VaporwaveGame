using Godot;
using System;

public partial class MusicManager : Node2D
{
	public static MusicManager Instance;
	
	[Export] private AudioStreamPlayer2D main;
	[Export] private AudioStreamPlayer2D reset;

	public override void _Ready()
	{
		Instance = this;
		main.Finished += PlayMainTrack;
		reset.Finished += PlayResetTrack;
	}

	public void PlayMainTrack()
	{
		reset.Stop();
		main.Play();
	}

	public void PlayResetTrack()
	{
		main.Stop();
		reset.Play();
	}

	public void StopMusic()
	{
		main.Stop();
		reset.Stop();
	}

}
