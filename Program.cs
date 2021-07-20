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

			IGameSettingsLoader gsr = new GameSettingsLoader
			{
				SettingsDirectory = @"Inputs\"
			};

			var gamesSettings = gsr.LoadSettings();

			// if gamesSettings != null && gamesSettings.Any() { Print"No settings were found."}

			foreach (var gameSettings in gamesSettings)
			{
				Console.WriteLine("--------------------");
				Console.WriteLine("New game is started.");
				Console.WriteLine("--------------------");

				// you can say that you did some benchmarking and eventually, File.ReadLines was faster.
				var settings = File.ReadLines(gameSettings);

				IBoardGame em = new EscapeMines();

				em.SetupBoard(settings.Take(4).ToList());

				var movesSets = settings.Skip(4).Take(settings.Count());

				foreach (var movesSet in movesSets)
				{
					Console.WriteLine("\nPlaying moves:");
					em.Play(movesSet);
				}

				em.Result();
				//em.End();
			}
			Console.ReadKey();
			//output			
		}
	}
}
