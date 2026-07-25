using Godot;
using System;
using System.Collections.Generic;

public partial class Camera2d : Camera2D
{
	private List<string> Respostas = new List<string> { "Ailton", "Faca", "Esfaqueado", "10:40", "Bunker" };

	private List<string> palavrasAcertadas = new List<string>();
	
	private void OnLineEditTextSubmitted(string newText)
	{
		bool acertouNovaPalavra = false;
		
		for (int i = 0; i < Respostas.Count; i++)
		{
			string ordem = Respostas[i];
			
			if (newText.Equals(ordem, StringComparison.OrdinalIgnoreCase))
			{
				if (!palavrasAcertadas.Contains(ordem))
				{
					palavrasAcertadas.Add(ordem);
					acertouNovaPalavra = true;
					break;
				}
			}
		}

		if (acertouNovaPalavra)
		{
			GD.Print($"{palavrasAcertadas.Count}/5.");

			if (palavrasAcertadas.Count == 5)
			{
				GD.Print("correto");
				GetNode<Window>("Window").Hide();
			}
		}
		else
		{
			
		}

		var campoTexto = GetNodeOrNull<LineEdit>("Window/LineEdit");
		if (campoTexto != null)
		{
			campoTexto.Text = "";
		}
	}
	
	private void OnWindowCloseRequested()
	{
		GetNode<Window>("Window").Hide();
	}
}
