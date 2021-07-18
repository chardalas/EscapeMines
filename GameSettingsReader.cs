using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EscapeMinesChardalasEmmanouil
{
	class GameSettingsReader : IGameSettingsReader
	{
		private string settingsDirectory;
		private string currentDirectory;

		public string SettingsDirectory { set => settingsDirectory = value; }

		public GameSettingsReader()
		{
			currentDirectory = Environment.CurrentDirectory;
		}

		public IEnumerable<string> ReadSettings()
		{
			string settingsDirectoryFullPath = Path.Combine(Directory.GetParent(currentDirectory).Parent.FullName, settingsDirectory);

			return from file in Directory.EnumerateFiles(settingsDirectoryFullPath, "*.txt") select file;
		}
	}
}
