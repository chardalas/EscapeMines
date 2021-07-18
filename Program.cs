using System;
using System.IO;
using System.Linq;

namespace EscapeMinesChardalasEmmanouil
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the Escape Mines.\n");

			IGameSettingsReader gsr = new GameSettingsReader
			{
				SettingsDirectory = @"EscapeMinesInputs\"
			};

			var gamesSettings = gsr.ReadSettings();

			foreach (var gameSettings in gamesSettings)
			{
				// you can say that you did some benchmarking and eventually, File.ReadLines was faster.
				var lines = File.ReadLines(gameSettings);

				Console.WriteLine(lines.First());
				Console.WriteLine(lines.Skip(1).First());
				Console.WriteLine(lines.Skip(2).First());
				Console.WriteLine(lines.Skip(3).First());
				Console.WriteLine(lines.Skip(4).FirstOrDefault());
				Console.WriteLine("\nNew Game Has Started.\n");

				Console.ReadLine();
			}
			Console.ReadKey();

			IBoardGame em = new EscapeMines();
			
			em.SetupBoard();
			em.Play();
			em.Result();
			//em.End();

			//output
			// either success or failure
			// if the turtle does not reach the exit or doesn't hit a mine.
		}
	}
}
