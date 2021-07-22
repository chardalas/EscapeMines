using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
	public interface IBoardGame
	{
		IBoard Board { get; }
		List<IPawn> Pawns { get; }
		string Result { get; }

		void Play(string movesSet);
		void SetupBoard(List<string> settings);
		void ResetPawn();
	}
}