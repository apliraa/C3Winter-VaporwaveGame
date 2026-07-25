using Godot;
using System;
using System.Collections.Generic;

public partial class Camera2d : Camera2D
{
	private List<string> Answears = new List<string> { "Ailton", "Faca", "Esfaqueado", "10:40", "Bunker" };

	private List<string> Dialogue = new List<string>
	{
		"Qual o nome do assassino?",
		"Qual a arma utilizada no crime?",
		"Qual a causa da morte?",
		"Qual o horário do assassinato? (hh:mm):",
		"Onde o corpo foi encontrado?",
	
	};

	private List<string> wordsRight = new List<string>();

	private RichTextLabel labelDialogue;

	public override void _Ready()
	{
		labelDialogue = GetNode<RichTextLabel>("Window/Panel/Label");

		if(labelDialogue == null)
		{
			GD.PrintErr("Erro: O nó 'Window/Dialogue' não foi encontrado.");
		}

		else
		{
			
		}

		UpdateDialogue();
	}
	

	private void OnLineEditTextSubmitted(string newText)
	{
		
		if (wordsRight.Count >= Answears.Count)
		{
			return;
		}
		
		bool gotWordRight = false;
		
		int currentIndex = wordsRight.Count;

		string expectedAnswer = Answears[currentIndex];

		if (newText.Equals(expectedAnswer, StringComparison.OrdinalIgnoreCase))
		{
			wordsRight.Add(expectedAnswer);
			gotWordRight = true;
		}		

		if (gotWordRight)
		{
			GD.Print($"{wordsRight.Count}/5.");

			if (wordsRight.Count == 5)
			{
				GD.Print("correto");
				GetNode<Window>("Window").Hide();
			}
		}
		else
		{
			wordsRight.Clear();
		}

		var campoTexto = GetNodeOrNull<LineEdit>("Window/LineEdit");
		if (campoTexto != null)
		{
			campoTexto.Text = "";
		}

		UpdateDialogue();

	}

	private void UpdateDialogue()
	{
		if (labelDialogue != null && wordsRight.Count < Dialogue.Count)
		{
			labelDialogue.Text = Dialogue[wordsRight.Count];
			labelDialogue.Visible = true;
		}
	}
	
	private void OnWindowCloseRequested()
	{
		GetNode<Window>("Window").Hide();
	}
}
