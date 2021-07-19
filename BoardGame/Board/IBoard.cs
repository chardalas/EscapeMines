using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
	interface IBoard
	{
		int Size { get; set; }
		List<ITile> Tiles { get; set; }

		void CreateTiles();
	}
}
