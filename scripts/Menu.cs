using Godot;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

public partial class Menu : Control
{

	[Export] public Label Nome;

	[Export] public Button INICIAR;
	
	public override void _Ready()
	{

		if (Nome != null && Nome.Material != null)
		{
			
			Nome.Material = (Material)Nome.Material.Duplicate();
		
		}
	
		PararGlitch();

		if (INICIAR != null)
		{
			
			INICIAR.Disabled = true;
		
		}

		_ = SequênciaInicial();

	}

	private async Task SequênciaInicial()
	{
		
		await Task.Delay(2500);
		
		IniciarGlitch(0.5f, 0.02f);
		
		await Task.Delay(300);

		PararGlitch();

		await Task.Delay(2000);

		IniciarGlitch(0.6f, 0.03f);

		await Task.Delay(150);

		if (Nome != null)
		{
			
			Nome.Text = "Cesare Martinez";

		}
		
		await Task.Delay(150);

		PararGlitch();

		if (INICIAR != null)
		{
			
			INICIAR.Disabled = false;
		
		}
	
	}

	public void IniciarGlitch(float intensidade = 0.2f, float aberracao = 0.01f)
	{
		if (Nome?.Material is ShaderMaterial shaderMat)
		{
			
			shaderMat.SetShaderParameter("glitch_amount", intensidade);
			
			shaderMat.SetShaderParameter("shift_amount", aberracao);
		}

	}
	
	public void PararGlitch()
	{
		
		if (Nome?.Material is ShaderMaterial shaderMat)
		{
			
			shaderMat.SetShaderParameter("glitch_amount", 0.0f);
			
			shaderMat.SetShaderParameter("shift_amount", 0.0f);
		
		}
	
	}

	public void _on_INICIAR_pressed()
	{
		
		GetTree().ChangeSceneToFile("res://scenes/root.tscn");
	
	}
}
