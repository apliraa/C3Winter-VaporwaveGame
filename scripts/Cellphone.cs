using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Cellphone : Control
{

	private List<string> Answears = new List<string> { "Ailton", "Veneno", "Envenenamento", "00:00", "Bunker" };

	private List<string> Dialogue = new List<string>
	{
		"Qual o nome do assassino?",
		"Qual a arma utilizada no crime?",
		"Qual a causa da morte?",
		"Qual o horário do ocorrido?:",
		"Onde o corpo foi encontrado?",
	
	};

	private List<string> wordsRight = [];
	[Export] private RichTextLabel labelDialogue;
	[Export] private LineEdit campoTexto;
	
	[Export] private Celphone2 telaIdle;

	private int currIndex = -1;

	public override void _Ready()
	{
		UpdateDialogue();
	}
	

	public void _on_line_edit_text_submitted(string newDialogue)
	{
		campoTexto.Text = "";
		if (wordsRight.Count >= Answears.Count) return;
		if (newDialogue.ToLower() == Answears[currIndex].ToLower()) wordsRight.Add(Answears[currIndex]);
		UpdateDialogue();
	}

	public void verifyAnswers()
	{
		Hide();
		telaIdle.Show();

		if (wordsRight.SequenceEqual(Answears))
			GD.Print("Todas as respostas corretas");

		currIndex = 0;
		wordsRight = [];
	}

	private void UpdateDialogue()
	{
		currIndex++;

		if (currIndex == 5)
		{
			verifyAnswers();
			return;
		}

		labelDialogue.Text = Dialogue[currIndex];
	}

}
