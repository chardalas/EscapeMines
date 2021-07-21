using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BoardGameChardalasEmmanouil
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the Escape Mines.");

			IGameSettings  ems = new EscapeMinesSettings
			{
				SettingsDirectory = @"Inputs\"
			};

			var gamesSettings = ems.Load();

			// if gamesSettings != null && gamesSettings.Any() { Print"No settings were found."}

			foreach (var gameSettings in gamesSettings)
			{
				var settings = File.ReadLines(gameSettings);

				var settingsNotValid = ems.Validate(settings.ToList());				

				if (settingsNotValid)
				{
					Console.ReadKey();
					return;
				}

				Console.WriteLine("--------------------");
				Console.WriteLine("New game is started.");
				Console.WriteLine("--------------------");

				IBoardGame em = new EscapeMines();
				
				var tt = ems.SanitizedSettings;

				em.SetupBoard(settings.Take(4).ToList());

				var movesSets = settings.Skip(4).Take(settings.Count());

				foreach (var movesSet in movesSets)
				{
					Console.WriteLine("\nPlaying moves:");
					em.Play(movesSet);
				}

				em.Result();
			}
			Console.ReadKey();
		}
	}
}
