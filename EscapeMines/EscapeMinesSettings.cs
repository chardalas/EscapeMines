using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BoardGameChardalasEmmanouil
{
	class EscapeMinesSettings : IGameSettings
	{
		private string settingsDirectory;
		private string currentDirectory;

		public List<string> SanitizedSettings { get; }
		public string SettingsDirectory { set => settingsDirectory = value; }

		public EscapeMinesSettings()
		{
			currentDirectory = Environment.CurrentDirectory;
			SanitizedSettings = new List<string>();
		}

		public IEnumerable<string> Load()
		{
			string settingsDirectoryFullPath = Path.Combine(Directory.GetParent(currentDirectory).Parent.FullName, settingsDirectory);

			return from file in Directory.EnumerateFiles(settingsDirectoryFullPath, "*.txt") select file;
		}

		public bool Validate(List<string> settings)
		{
			// If more settings come in, this becomes cumbersome to maintain.
			if (!settings.Any())
			{
				Console.WriteLine("\nInvalid input: No settings were found.\n");
				return true;
			}

			return ValidateNonZeroMatrix(settings[0]) ||
				ValidatePairOfNumbers(settings[0]) ||
				ValidateMines(settings[1]) ||
				ValidatePairOfNumbers(settings[2]) ||
				ValidateStartingPoint(settings[3]) ||
				ValidateMovesSets(settings.Skip(4).Take(settings.Count()));
		}

		private bool ValidateNonZeroMatrix(string input)
		{
			Regex boardSize = new Regex(@"0 0");

			if (string.IsNullOrEmpty(input) || boardSize.IsMatch(input))
			{
				Console.WriteLine("\nInvalid input: {0}", input);
				Console.WriteLine("Settings requires a non zero dimensions matrix.");

				return true;
			}

			return false;
		}

		private bool ValidatePairOfNumbers(string input)
		{
			Regex boardSize = new Regex(@"^[0-9]+ [0-9]+");

			if (string.IsNullOrEmpty(input) || !boardSize.IsMatch(input))
			{
				Console.WriteLine("\nInvalid input: {0}", input);
				Console.WriteLine("Settings requires an input that begins with two numbers separated by space: 1 2");

				return true;
			}

			SanitizedSettings.Add(boardSize.Match(input).Value);

			return false;
		}

		private bool ValidateMines(string input)
		{
			Regex mines = new Regex(@"([0-9]+(,[0-9]+))*");

			if (string.IsNullOrEmpty(input) || !mines.IsMatch(input))
			{
				Console.WriteLine("\nInvalid input: {0}", input);
				Console.WriteLine("Settings requires two numbers separated by comma: 1,2");

				return true;
			}

			StringBuilder matches = new StringBuilder();

			foreach (Match match in mines.Matches(input))
			{
				if (match.Length > 0)
				{
					matches.Append(match).Append(" ");
				}
			}
			
			SanitizedSettings.Add(matches.ToString());

			return false;
		}

		private bool ValidateStartingPoint(string input)
		{
			Regex startingPoint = new Regex(@"([0-9]+ [0-9]+) [NSEW]");

			if (string.IsNullOrEmpty(input) || !startingPoint.IsMatch(input))
			{
				Console.WriteLine("\nInvalid input: {0}", input);
				Console.WriteLine("Settings requires an input that begins with two numbers separated by space followed by a char [NSEW]: 1 2 E");

				return true;
			}

			SanitizedSettings.Add(startingPoint.Match(input).Value);

			return false;
		}

		private bool ValidateMovesSets(IEnumerable<string> movesSets)
		{
			if (!movesSets.Any())
			{
				Console.WriteLine("\nInvalid input: A sequence of moves is required.\n");
				return true;
			}

			Regex moves = new Regex(@"[^LRM]");

			foreach (var movesSet in movesSets)
			{
				SanitizedSettings.Add(moves.Replace(movesSet, string.Empty));
			}

			return false;
		}
	}
}
