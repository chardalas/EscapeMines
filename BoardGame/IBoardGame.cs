using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
	interface IBoardGame
	{
		IBoard Board { get; }
		List<IPawn> Pawns { get; }

		string Result();
		void Play(string movesSet);
		void SetupBoard(List<string> settings);
	}
}