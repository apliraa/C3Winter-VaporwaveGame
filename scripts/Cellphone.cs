using Godot;
using System;
using System.Collections.Generic;

public partial class Cellphone : Control
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
	private Label labelDialogue;
	private LineEdit campoTexto;

	public override void _Ready()
	{
		labelDialogue = GetNodeOrNull<Label>("TextureRect/Label");

		campoTexto = GetNodeOrNull<LineEdit>("TextureRect/LineEdit");

		if(campoTexto != null)
		{
			campoTexto.TextSubmitted -= _on_line_edit_text_submitted;
			campoTexto.TextSubmitted += _on_line_edit_text_submitted;
		}

		UpdateDialogue();
	}
	

	public void _on_line_edit_text_submitted(string newDialogue)
	{
		
		if (wordsRight.Count >= Answears.Count)
		{
			return;
		}
		
		

		int currentIndex = wordsRight.Count;

		string expectedAnswer = Answears[currentIndex];

		if (newDialogue.Equals(expectedAnswer, StringComparison.OrdinalIgnoreCase))
		{
			wordsRight.Add(expectedAnswer);
			GD.Print($"{wordsRight.Count}/5");
			
			if (wordsRight.Count == Answears.Count)
			{
				verifyAnswers();
			}
		}
	
		else
		{
			wordsRight.Clear();
		}

		if (campoTexto != null)
		{
			campoTexto.Text = "";
		}
		
		UpdateDialogue();
	}

	public void verifyAnswers()
	{
		Hide();
		
		GD.Print("Todas as respostas corretas");
	}

	private void UpdateDialogue()
	{
		if (labelDialogue != null && wordsRight.Count < Dialogue.Count)
		{
			labelDialogue.Text = Dialogue[wordsRight.Count];
			labelDialogue.Visible = true;
		}
	}
}
