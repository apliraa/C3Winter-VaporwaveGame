using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Cellphone : Control
{
	private List<List<string>> Answears = new List<List<string>> 
	{ 
		new List<string>{"Júlio Batista", "Julio Batista"}, 
		new List<string>{"Toxina", "Veneno"},
		new List<string>{"Envenenamento"},
		new List<string>{"00:00", "Meia Noite", "0000"},
		new List<string>{"Bunker"}
	};

	private List<string> Dialogue = new List<string>
	{
		"Qual o nome do assassino?",
		"Qual a arma do crime?",
		"Qual a causa da morte?",
		"Qual o horário do ocorrido?",
		"Onde o corpo foi encontrado?"
	};

	private List<string> wordsRight = new List<string>();
	
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
		
		if (currIndex >= Answears.Count) return;

		string respostaJogador = newDialogue.ToLower().Trim();

		bool respostaCorreta = Answears[currIndex].Any(respostaValida => respostaValida.ToLower().Trim() == respostaJogador);

		if (respostaCorreta) 
		{
			wordsRight.Add(respostaJogador);
		}
		
		UpdateDialogue();
	}

	public void verifyAnswers()
	{
		Hide();
		telaIdle.Show();

		if (wordsRight.Count == Answears.Count)
		{
			GetTree().ChangeSceneToFile("res://scenes/ending_screen.tscn");
		}

	
		currIndex = -1; 
		wordsRight.Clear();
	}

	private void UpdateDialogue()
	{
		currIndex++;

		if (currIndex >= Dialogue.Count)
		{
			verifyAnswers();
			return;
		}

		labelDialogue.Text = Dialogue[currIndex];
	}
}
