namespace BoardGameChardalasEmmanouil
{
    public interface IEscapeMinesSettingsValidator : IGameSettingsValidator
    {
        bool ValidateNonZeroMatrix();
        bool ValidateBoardSize();
        bool ValidateMines();
        bool ValidateExitPoint();
        bool ValidateStartingPoint();
        bool ValidateMovesSets();

    }
}
