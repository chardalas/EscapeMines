using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
			// If more settings come in, this becomes cumbersome to maintain
			if (!settings.Any())
			{
				Console.WriteLine("\nInvalid input: No settings were found.\n");
				return true;
			}

			Regex digits = new Regex(@"[^\d]");
			Regex position = new Regex(@"[^0-9NSWE]");

			var boardSize = ValidateLength(digits.Replace(settings[0], string.Empty), 2);

			var mines = ValidateMines(digits.Replace(settings[1], string.Empty));

			var exitPoint = ValidateLength(digits.Replace(settings[2], string.Empty), 2);

			var startingPoint = ValidateLength(position.Replace(settings[3], string.Empty), 3);

			var movesSets = ValidateMovesSets(settings.Skip(4).Take(settings.Count()));

			return boardSize || mines || exitPoint || startingPoint || movesSets;
		}

		private bool ValidateLength(string input, int length)
		{
			if (input.Length > length || input.Length == 0)
			{
				Console.WriteLine("\nInvalid input: `{0}` \n", input);
				return true;
			}

			SanitizedSettings.Add(input);

			return false;
		}

		private bool ValidateMines(string input)
		{	
			if (input.Length % 2 != 0 || input.Length == 0)
			{
				Console.WriteLine("\nInvalid input: `{0}` \n", input);
				return true;
			}

			SanitizedSettings.Add(input);

			return false;
		}

		private bool ValidateMovesSets(IEnumerable<string> movesSets)
		{
			if (!movesSets.Any())
			{
				Console.WriteLine("\nInvalid input: A sequence of moves is required. \n");
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
