using Godot;
using System;

public partial class MusicManager : AudioStreamPlayer2D
{
	public static MusicManager Instance;
	
	[Export] private AudioStreamPlayer2D main;
	[Export] private AudioStreamPlayer2D reset;

	public override void _Ready()
	{
		Instance = this;
	}

	public void PlayMainTrack()
	{
		main.Play();
	}

	public void PlayResetTrack()
	{
		reset.Play();
	}

	public void StopMusic()
	{
		main.Stop();
		reset.Stop();
	}

}
