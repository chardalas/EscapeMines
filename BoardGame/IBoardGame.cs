using System.Collections.Generic;

namespace EscapeMinesChardalasEmmanouil
{
	internal interface IBoardGame
	{
		IBoard Board { get; }
		IPawn Turtle { get; }

		void SetupBoard(IEnumerable<string> settings);
		void Play();
		string Result();
	}
}