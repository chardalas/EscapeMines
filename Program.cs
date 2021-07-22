using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BoardGameChardalasEmmanouil
{
	class Program
	{

		// ToDo :: For testing:
		// Test all EscapeMines methods
		// Test all EscapeMinesBoard methods
		// Test all EscapeMinesSettings methods		

		static void Main(string[] args)
		{
			IGameSettings ems = new EscapeMinesSettings
			{
				SettingsDirectory = @"Inputs\"
			};

			var gamesSettings = ems.Load();

			if (gamesSettings != null && !gamesSettings.Any()) { Console.Write("No file settings were found."); Console.ReadLine(); return; }

			Console.WriteLine("Welcome to the Escape Mines.");

			foreach (var gameSettings in gamesSettings)
			{
				var settings = File.ReadLines(gameSettings);

				var settingsNotValid = ems.Validate(settings.ToList());

				if (settingsNotValid) { Console.ReadLine(); return; }

				Console.Write("\n-------------------- New game is started --------------------\n");

				IBoardGame em = new EscapeMines();

				em.SetupBoard(ems.SanitizedSettings.Take(4).ToList());

				var movesSets = ems.SanitizedSettings.Skip(4).Take(ems.SanitizedSettings.Count());

				foreach (var movesSet in movesSets)
				{
					Console.Write("\nPlaying moves:\n");
					em.Play(movesSet);
					Console.Write(em.Result);
					Console.ReadLine();
				}
			}
			Console.ReadLine();
		}
	}
}
