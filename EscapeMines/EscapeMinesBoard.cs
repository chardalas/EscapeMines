using System;
using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
	class EscapeMinesBoard : IBoard
	{
		public int Width { get; set; }
		public int Length { get; set; }
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

		public void Print()
		{
			foreach (var item in Tiles)
			{
				Console.WriteLine("Tile:: " + item + " x:: " + item.Coordinates.x + " y:: " + item.Coordinates.y + "\n");
			}
		}

		public int GetTileIndex(int x, int y)
		{
			var index = Tiles.FindIndex(t => t.Coordinates.x == x && t.Coordinates.y == y);

			if (index == -1)
			{
				PrintError1(x, y);
			}

			return index;
		}

		private void PrintError1(int x, int y)
		{			
			Console.WriteLine("The board expands from tiles: (0,0) up to ({0},{1})", Width - 1, Length - 1);
			Console.WriteLine("The tile with coordinates: ({0},{1}) does not exits. Please amend the input and try again.", x, y);
			Console.ReadLine();
			Environment.Exit(1);
		}		
	}
}
