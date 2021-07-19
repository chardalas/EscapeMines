using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
	interface IGameSettingsReader
	{
		string SettingsDirectory { set; }
		IEnumerable<string> ReadSettings();
	}
}
