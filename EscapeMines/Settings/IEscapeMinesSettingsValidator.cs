using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
    public interface IEscapeMinesSettingsValidator : IGameSettingsValidator
    {
        bool ValidateNonZeroMatrix(string input);
        bool ValidateBoardSize(string input);
        bool ValidateMines(string input);
        bool ValidateExitPoint(string input);
        bool ValidateStartingPoint(string input);
        bool ValidateMovesSets(IEnumerable<string> movesSets);
    }
}
