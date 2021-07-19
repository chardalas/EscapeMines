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
			this.Board = new EscapeMinesBoard(); // Board (list of tiles) is crated here.
			this.Pawns = new List<IPawn>();
		}

		public void SetupBoard(IEnumerable<string> settings)
		{
			Board.Size = settings.FirstOrDefault().Trim();
			SetMines(settings.Skip(1).First());
			SetExit(settings.Skip(2).First());
			SetTurtle(settings.Skip(3).First());

			foreach (var item in Board.Tiles)
			{
				Console.WriteLine("Board:: " + item.Coordinates.x + " " + item.Coordinates.y + "\n");
			}

			foreach (var item in Pawns)
			{
				Console.WriteLine("Pawn:: " + item.Coordinates.x + " " + item.Coordinates.y + " " + item.Orientation + "\n");
			}
		}

		private void SetMines(string mines)
		{
			//todo: what if a mine is out of bounds? Wll always have to be less that the board size.
			foreach (var mine in mines.Trim().Split(' '))
			{
				var points = mine.Split(',');

				Board.Tiles.Add(new Mine { Coordinates = new Coordinates { x = points[0], y = points[1] } });
			}

			var mi = Board.Tiles.OfType<Mine>().Where(x => x.Coordinates.x == "1" && x.Coordinates.y == "1");

			foreach (var item in mi)
			{
				Console.WriteLine("Mine position:: (" + item.Coordinates.x + "," + item.Coordinates.y + ")");
			}
		}

		private void SetExit(string exit)
		{
			// todo: what if a exit is out of bounds? Will always have to be less that the board size.
			var points = exit.Split(' ');

			Board.Tiles.Add(new Exit { Coordinates = new Coordinates { x = points[0], y = points[1] } });
		}

		private void SetTurtle(string turtle)
		{
			//todo: what if turtle is out of bounds? will always have to be less that the board size.
			var points = turtle.Split(' ');

			Pawns.Add(new Turtle { Coordinates = new Coordinates { x = points[0], y = points[1] }, Orientation = points[2] });
		}

		public void Play() { }

		public string Result() { return ""; }
	}
}
