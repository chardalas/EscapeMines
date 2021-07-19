using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
	interface IBoard
	{
		int Size { get; set; }
		int Width { get; set; }
		int Length { get; set; }
		List<ITile> Tiles { get; set; }

		void CreateTiles();
	}
}
