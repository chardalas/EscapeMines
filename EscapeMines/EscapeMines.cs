using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGameChardalasEmmanouil
{
	class EscapeMines : IBoardGame
	{
		public IBoard Board { get; }
		public List<IPawn> Pawns { get; }

		public EscapeMines()
		{
			this.Board = new EscapeMinesBoard(); // Board (list of tiles) is created.
			this.Pawns = new List<IPawn>();
		}

		public void SetupBoard(IEnumerable<string> settings)
		{
			// var tri= Regex.Replace(settings.FirstOrDefault(), @"\s+", "");
			// todo: validate input

			// Execute the settings one after the other.
			SetupBoardSize(settings.First());
			Board.CreateTiles();
			SetupMines(settings.Skip(1).First());
			SetupExit(settings.Skip(2).First());
			SetupTurtle(settings.Skip(3).First());
			Board.Print();
			PrintMines();
			PrintPawns();
		}

		public void Play() { }

		public string Result() { return ""; }

		private void SetupBoardSize(string input)
		{
			int[] boardDimensions = Array.ConvertAll(input.Trim().Split(' '), int.Parse);

			Board.Width = boardDimensions[0];
			Board.Length = boardDimensions[1];
		}

		private void SetupMines(string input)
		{
			// todo: validate input
			//ntodo: what if a mine is out of bounds? Wll always have to be less that the board size.
			foreach (var mine in input.Trim().Split(' '))
			{
				int[] points = Array.ConvertAll(mine.Trim().Split(','), int.Parse);

				var tileIndex = Board.Tiles.FindIndex(x => x.Coordinates.x == points[0] && x.Coordinates.y == points[1]);

				// plant the mine
				Board.Tiles[tileIndex] = new Mine { Coordinates = new Coordinates { x = points[0], y = points[1] } };
			}

			var mi = Board.Tiles.OfType<Mine>().Where(x => x.Coordinates.x == 1 && x.Coordinates.y == 1);

			foreach (var item in mi)
			{
				Console.WriteLine("Mine position:: (" + item.Coordinates.x + "," + item.Coordinates.y + ")");
			}
		}

		private void SetupExit(string input)
		{
			// todo: validate input
			// todo: what if a exit is out of bounds? Will always have to be less that the board size.
			int[] points = Array.ConvertAll(input.Trim().Split(' '), int.Parse);

			var tileIndex = Board.Tiles.FindIndex(x => x.Coordinates.x == points[0] && x.Coordinates.y == points[1]);
			
			Board.Tiles[tileIndex] = new Exit { Coordinates = new Coordinates { x = points[0], y = points[1] } };

			//Board.Tiles.Add(new Exit { Coordinates = new Coordinates { x = points[0], y = points[1] } });
		}

		private void SetupTurtle(string input)
		{
			// todo: validate input
			//todo: what if turtle is out of bounds? will always have to be less that the board size.
			var inputArr = input.Trim().Split(' ');

			int[] points = Array.ConvertAll(inputArr.Take(inputArr.Length - 1).ToArray(), int.Parse);

			Pawns.Add(new Turtle { Coordinates = new Coordinates { x = points[0], y = points[1] }, Orientation = inputArr[2] });
		}

		private void PrintPawns()
		{
			foreach (var item in Pawns)
			{
				Console.WriteLine("Pawn:: " + item.Coordinates.x + " " + item.Coordinates.y + " " + item.Orientation + "\n");
			}
		}

		private void PrintMines()
		{
			foreach (var item in Board.Tiles.OfType<Mine>())
			{
				Console.WriteLine("Mine:: " + item.Coordinates.x + " " + item.Coordinates.y + "\n");
			}
		}
	}
}
