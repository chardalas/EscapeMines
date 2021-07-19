using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
	class EscapeMinesBoard : IBoard
	{
		private int size { get; set; }

		public int Width { get; set; }
		public int Length { get; set; }
		public int Size { get { return size; } set { size = value; } }
		public string Exit { get; set; }
		public string Mines { get; set; }
		public List<ITile> Tiles { get; set; }

		public EscapeMinesBoard()
		{
			this.Tiles = new List<ITile>();
		}

		public void CreateTiles()
		{
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Length; j++)
				{
					Tiles.Add(new Tile { Coordinates = new Coordinates { x = i, y = j } });
				}
			}
		}

		void SetMines() { }

		void SetStartingPoint() { }

		void SetExitPoint() { }
	}
}
