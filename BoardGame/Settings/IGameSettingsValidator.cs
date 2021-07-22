using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
    public interface IGameSettingsValidator
    {
        List<string> Settings { get; set; }
        List<string> SanitizedSettings { get; }
    }
}
