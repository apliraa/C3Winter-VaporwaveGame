using Godot;
using System;

public partial class MusicButton : Node2D
{
	private enum MButtons { Stop, Play1, Play2 }
	[Export] private MButtons buttonType;

	[Export] private AnimatedSprite2D as2d;

	public override void _Ready()
	{
		as2d.Frame = (int)buttonType;
	}

	public void _on_button_pressed()
	{
		switch (buttonType)
		{
			case MButtons.Stop:
			MusicManager.Instance.StopMusic();
			break;

			case MButtons.Play1:
			MusicManager.Instance.PlayResetTrack();
			break;

			case MButtons.Play2:
			MusicManager.Instance.PlayMainTrack();
			break;
		}
	}

}
