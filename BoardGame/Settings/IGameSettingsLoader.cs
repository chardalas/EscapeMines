using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
    public interface IGameSettingsLoader
    {
        string SettingsDirectory { set; }
        List<string> SanitizedSettings { get; }

        IEnumerable<string> Load();        
    }
}
