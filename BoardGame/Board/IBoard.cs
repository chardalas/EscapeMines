using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
	interface IBoard
	{
		string Size { get; set; }
		List<ITile> Tiles { get; set; }

		void CreateBoard();
		void SetSize();
	}
}
