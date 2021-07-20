using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BoardGameChardalasEmmanouil
{
	class GameSettingsLoader : IGameSettingsLoader
	{
		private string settingsDirectory;
		private string currentDirectory;

		public string SettingsDirectory { set => settingsDirectory = value; }

		public GameSettingsLoader()
		{
			currentDirectory = Environment.CurrentDirectory;
		}

		public IEnumerable<string> LoadSettings()
		{
			string settingsDirectoryFullPath = Path.Combine(Directory.GetParent(currentDirectory).Parent.FullName, settingsDirectory);

			return from file in Directory.EnumerateFiles(settingsDirectoryFullPath, "*.txt") select file;
		}
	}
}
