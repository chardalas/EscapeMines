using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BoardGameChardalasEmmanouil
{
	class EscapeMines : IBoardGame
	{
		public IBoard Board { get; }
		public List<IPawn> Pawns { get; }
		private int width;
		private int length;

		public EscapeMines()
		{
			this.Board = new EscapeMinesBoard(); // Board (list of tiles) is crated here.
			this.Pawns = new List<IPawn>();
		}

		//var tri= Regex.Replace(settings.FirstOrDefault(), @"\s+", "");
		public void SetupBoard(IEnumerable<string> settings)
		{
			int[] points = Array.ConvertAll(settings.FirstOrDefault().Trim().Split(' '), int.Parse);

			Board.Width = points[0];
			Board.Length = points[1];
			Board.CreateTiles();

			//Board.Tiles.in(AddRange(2, 10);
			SetMines(settings.Skip(1).First());
			SetExit(settings.Skip(2).First());
			SetTurtle(settings.Skip(3).First());

			foreach (var item in Board.Tiles)
			{
				Console.WriteLine("Tile:: " + item + " x:: " + item.Coordinates.x + " y:: " + item.Coordinates.y + "\n");
				//Console.WriteLine("Tile:: " + item.GetType() + "\n");
			}

			//foreach (var item in Board.Tiles.OfType<Mine>())
			//{
			//	Console.WriteLine("Board:: " + item.Coordinates.x + " " + item.Coordinates.y + "\n");
			//}

			foreach (var item in Pawns)
			{
				Console.WriteLine("Pawn:: " + item.Coordinates.x + " " + item.Coordinates.y + " " + item.Orientation + "\n");
			}
		}

		private void SetMines(string input)
		{
			// todo: validate input
			//ntodo: what if a mine is out of bounds? Wll always have to be less that the board size.
			foreach (var mine in input.Trim().Split(' '))
			{
				int[] points = Array.ConvertAll(mine.Trim().Split(','), int.Parse);

				var tileIndex = Board.Tiles.FindIndex(x => x.Coordinates.x == points[0] && x.Coordinates.y == points[1]);

				Board.Tiles[tileIndex] = new Mine { Coordinates = new Coordinates { x = points[0], y = points[1] } };
			}

			var mi = Board.Tiles.OfType<Mine>().Where(x => x.Coordinates.x == 1 && x.Coordinates.y == 1);

			foreach (var item in mi)
			{
				Console.WriteLine("Mine position:: (" + item.Coordinates.x + "," + item.Coordinates.y + ")");
			}
		}

		private void SetExit(string input)
		{
			// todo: validate input
			// todo: what if a exit is out of bounds? Will always have to be less that the board size.
			int[] points = Array.ConvertAll(input.Trim().Split(' '), int.Parse);

			Board.Tiles.Add(new Exit { Coordinates = new Coordinates { x = points[0], y = points[1] } });
		}

		private void SetTurtle(string input)
		{
			// todo: validate input
			//todo: what if turtle is out of bounds? will always have to be less that the board size.
			var inputArr = input.Trim().Split(' ');

			int[] points = Array.ConvertAll(inputArr.Take(inputArr.Length - 1).ToArray(), int.Parse);

			Pawns.Add(new Turtle { Coordinates = new Coordinates { x = points[0], y = points[1] }, Orientation = inputArr[2] });
		}

		public void Play() { }

		public string Result() { return ""; }
	}
}
