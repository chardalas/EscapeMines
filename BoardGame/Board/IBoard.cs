using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
	interface IBoard
	{	
		int Width { get; set; }
		int Length { get; set; }
		List<ITile> Tiles { get; set; }

		void CreateTiles();
		void Print();
	}
}
