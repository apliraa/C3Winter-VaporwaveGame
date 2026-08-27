using Godot;
using System;

public partial class Celphone2 : Control
{
	[Export] Marker2D PhoneMarker;

	[Export] private Cellphone telaChamado;
	bool isOut;
	Vector2 initialPosition;
	public override void _Ready()
	{
		initialPosition =  GlobalPosition;
	}


	public void _on_button_pressed(){

		if(PhoneMarker == null) return;
		Tween phoneTween = CreateTween().SetTrans(Tween.TransitionType.Sine);

		if ( !isOut){
			
			phoneTween.TweenProperty(this, "position:y", PhoneMarker.GlobalPosition.Y, 0.5f   );
			

		}
		else
		{
			phoneTween.TweenProperty(this, "position:y", initialPosition.Y, 0.5f   );
		}
		isOut = !isOut;
		
	}

	public void _on_call_pressed()
	{
		Hide();
		telaChamado.Show();
	}
		
}
	
