using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
	interface IGameSettings
	{
		string SettingsDirectory { set; }
		List<string> SanitizedSettings { get; }
		
		IEnumerable<string> Load();
		bool Validate(List<string> settings);
	}
}
