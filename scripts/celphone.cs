using Godot;
using System;
using System.Collections.Generic;

public partial class celphone : Control
{
	List<string> celphoneDialogue = new List<string>(10);
		int dialogueIndex = 0;
	
	
	public override void _Ready()
	{
	
	}

	public override void _Process(double delta)
	{
	}
	
	public void _on_line_edit_text_submitted(String nextDialogue){
		//tratar o input e dar append na lista de comparação
		// incrementar o indice pra passar para o prox dialogo
		//limpar o campo de texto
		
		//if(index > 4){
			//verifyAnswer();
		//}
		
	}
	
	public void verifyAnswer(){
		//verificar se a lista nova é igual a lista de respostas
	}

	
	
}
