using System;
using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
	class EscapeMinesBoard : IBoard
	{
		private int length;
		private int width;
		private int size { get; set; }
		public int Size { get; set; }
		public string Exit { get; set; }
		public string Mines { get; set; }
		public List<ITile> Tiles { get; set; }

		public EscapeMinesBoard()
		{
			this.Tiles = new List<ITile>();
		}

		public void CreateTiles()
		{
			for (int i = 0; i < size; i++)
			{
				Tiles.Add(new Tile { Coordinates = new Coordinates { x = i, y = i } });
			}
		}

		void SetMines() { }

		void SetStartingPoint() { }

		void SetExitPoint() { }
	}
}
