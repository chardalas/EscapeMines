using System.Collections.Generic;

namespace EscapeMinesChardalasEmmanouil
{
	interface IGameSettingsReader
	{
		string SettingsDirectory { set; }
		IEnumerable<string> ReadSettings();
	}
}
