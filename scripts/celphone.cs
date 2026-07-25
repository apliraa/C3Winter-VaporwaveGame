using Godot;
using System;
using System.Collections.Generic;

public partial class Celphone : Control
{

private List<string> Answears = new List<string> { "Júlio Batista", "Veneno", "Envenenamento", "00:00", "Bunker" };

	private List<string> Dialogue = new List<string>
	{
		"Qual o nome do assassino?",
		"Qual a arma utilizada no crime?",
		"Qual a causa da morte?",
		"Qual o horário do assassinato?",
		"Onde o corpo foi encontrado?",
	
	};

	private List<int> correctAnswers = new List<int>();
	private int dialogueIndex = 0;
	private Label labelDialogue;
	private LineEdit campoTexto;

	public override void _Ready()
	{
	
		GD.Print("sinal forte");
	
		labelDialogue = GetNodeOrNull<Label>("%Label");

		campoTexto = GetNodeOrNull<LineEdit>("%LineEdit");

		if(campoTexto != null)
		{
			campoTexto.TextSubmitted += OnTextSubmittedManual;
		}

		UpdateDialogue();
	}
	

	public void OnTextSubmittedManual(string newDialogue)
	{
		
		if (dialogueIndex >= Dialogue.Count)
		{
			return;
		}

		GD.Print($"{dialogueIndex}/{newDialogue}");

		string expectedAnswer = Answears[dialogueIndex];
		
		if (newDialogue.Equals(expectedAnswer, StringComparison.OrdinalIgnoreCase))
		{
			if (!correctAnswers.Contains(dialogueIndex))
			{
				correctAnswers.Add(dialogueIndex);
			}
		}
		else
		{
			GD.Print("Resposta incorreta: " + newDialogue);
		}

		if (campoTexto != null)
		{
			campoTexto.Text = "";
		}

		dialogueIndex++;
		
		UpdateDialogue();
	}
	private void verifyEnd()
	{
		GD.Print($"acertou {correctAnswers.Count}/{Answears.Count}");
		
		if (correctAnswers.Count == Answears.Count)
		{
			verifyAnswers();
		}
		else
		{
			correctAnswers.Clear();
			dialogueIndex = 0;
			UpdateDialogue();
		}
	}
	public void verifyAnswers()
	{
		Hide();
		
		GD.Print("Todas as respostas corretas");
	}

	private void UpdateDialogue()
	{
		if (labelDialogue != null && dialogueIndex < Dialogue.Count)
		{
			labelDialogue.Text = Dialogue[dialogueIndex];
			labelDialogue.Visible = true;
		}
		else
		{
		
			verifyEnd();
		}
	}
}
