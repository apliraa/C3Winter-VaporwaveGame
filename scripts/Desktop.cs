using Godot;
using System;
using System.Collections.Generic;


public partial class Desktop : Control
{
	[Export] private Sprite2D melt;
	[Export] private Sprite2D gradient;

	public void StartCorruption(int time)
	{
		Tween tG = CreateTween();
		Tween tB = CreateTween();

		if (gradient.Material is ShaderMaterial s)
		{
			tG.TweenProperty(s,"shader_parameter/shift_color:g",0,time);
			tB.TweenProperty(s,"shader_parameter/shift_color:b",0,time).Connect("finished",Callable.From(Melt));
		}
	}

	private void Melt()
	{
		Tween t = CreateTween();

		if (melt.Material is ShaderMaterial s)
			t.TweenProperty(s,"shader_parameter/progress",1,5).Connect("finished",Callable.From(CorruptionCompleted));
	}

	private void CorruptionCompleted()
	{
		SignalBus.Instance.EmitSignal(SignalBus.SignalName.CorruptionCompleted);
	}
}
