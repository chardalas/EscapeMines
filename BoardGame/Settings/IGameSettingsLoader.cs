using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
	interface IGameSettingsLoader
	{
		string SettingsDirectory { set; }
		IEnumerable<string> LoadSettings();
	}
}
