using Godot;
using System;
using System.Linq;

public partial class AppManager : Node2D
{
	[Export] private Arquivos[] apps;
	[Export] private Arquivos[] arquivos;


	public override void _Ready()
	{
		ChooseAppsDisplayed();
		ChooseArquivesDisplayed();
	}

	private Arquivos[] SelectRandomApps()
	{
		Random.Shared.Shuffle(apps); 
		Arquivos[] randApps = [apps[0],apps[1]];
		return randApps;
	}

	private Arquivos[] SelectRandomArquives()
	{
		int amount = Random.Shared.Next(0, arquivos.Length + 1);
		return Random.Shared.GetItems(arquivos, amount);
	}

	private void ChooseAppsDisplayed()
	{
		Arquivos[] displayedApps = [];

		bool selected = false;
		while (!selected)
		{
			displayedApps = SelectRandomApps();
			selected = true;
			if (SaveManager.Instance.lastDisplayedApps == null) break;
			else if (
				SaveManager.Instance.lastDisplayedApps.Contains(displayedApps[0].Name) &&
				SaveManager.Instance.lastDisplayedApps.Contains(displayedApps[1].Name))
			{
				selected = false;
			}
		}

		SaveManager.Instance.lastDisplayedApps = [];
		foreach (Arquivos app in displayedApps)
		{
			SaveManager.Instance.lastDisplayedApps.Add(app.Name);
			app.Show();
		}
			
	}

	private void ChooseArquivesDisplayed()
	{
		foreach (Arquivos arquive in SelectRandomArquives())
			arquive.Show();
	}

}
