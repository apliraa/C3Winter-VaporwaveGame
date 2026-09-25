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
	[Export] private LineEdit campoTexto;
	[Export] private Celphone2 telaIdle;
	[Export] private RichTextLabel labelDialogue; 
	private int currIndex = 0;
	public override void _Ready()
	{
		
		ResetQuestions();
	
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

		currIndex++;
		
		UpdateDialogue();

	}

	public void verifyAnswers()
	{		

		if (wordsRight.Count == Answears.Count)
		{
			GetTree().ChangeSceneToFile("res://scenes/ending_screen.tscn");
			return;
		}

		labelDialogue.Text = "";

		if (wordsRight.Count == 0)
		{
			
			labelDialogue.Text = "As informações não parecem estar corretas, tente novamente.";
			
		}

		else if (wordsRight.Count == 1)
		{
			
			labelDialogue.Text = "Parece um bom começo, mas muitas informações não batem, tente outra coisa.";
			
		}

		else if (wordsRight.Count == 2 || wordsRight.Count == 3)
		{
			
			labelDialogue.Text = "Sinto que você está no caminho certo, mas ainda há informações incorretas.";
			
		}

		else if (wordsRight.Count == 4)
		{
			
			labelDialogue.Text = "Você está quase lá, mas ainda falta alguma coisa para podermos agir.";

		}

		campoTexto.Editable = false;
		
		GetTree().CreateTimer(3.0f).Timeout += () =>
		{
			
			labelDialogue.Text = "";

			campoTexto.Editable = true;
			
			Hide();
			
			if (telaIdle != null) telaIdle.Show();
		
			ResetQuestions();
		
		};
	
	}

	private void UpdateDialogue()
	{

		if (currIndex >= Dialogue.Count)
		{

			verifyAnswers();
			
			return;
		
		}

		labelDialogue.Text = Dialogue[currIndex];
	
	}

	private void ResetQuestions()
	{
		
		currIndex = 0;
		
		wordsRight.Clear();
		
		if (campoTexto != null) campoTexto.Text = "";
		
		if (labelDialogue != null && Dialogue.Count > 0) 
		
		{

			labelDialogue.Text = Dialogue[0];
		}

	
	}

		public void _on_off_pressed()
	{

		ResetQuestions();
		
		Hide();

		if (telaIdle != null) telaIdle.Show();

	}
}