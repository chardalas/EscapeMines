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
			this.Board = new EscapeMinesBoard();
			this.Pawns = new List<IPawn>();
		}

		public void SetupBoard(IEnumerable<string> settings)
		{
			Board.Size = settings.FirstOrDefault().Trim();
			Board.CreateBoard();

			SetMines(settings.Skip(1).First());
			SetExit(settings.Skip(2).First());

			//SetTurtle(settings.Skip(3).First());

			// Board.Tiles.Add(new Mine { Position = new Coordinates { x = 1, y = 2 } });
			// Board.Tiles.Add(new Exit { Position = new Coordinates { x = 1, y = 3 } });
			// Board.Tiles.Add(new Turtle { Position = new Coordinates { x = 1, y = 3 } });
			// Pawns.Add(new Turtle { });
			// em.Board.Size = 4 5;
			// em.Mines.Potition = 1,0 1,2 3,4;
			// em.Exit.Potition = 1,0 1,2 3,4;
			// em.Turtle.Potition = 1 0 N;

		}

		private void SetMines(string mines)
		{
			//todo: what if a mine is out of bounds?
			// will always have to be less that the board size.
			foreach (var mine in mines.Trim().Split(' '))
			{
				var points = mine.Split(',');

				Board.Tiles.Add(
					new Mine
					{
						Coordinates = new Coordinates
						{
							x = points[0],
							y = points[1]
						}
					});
			}

			var mi = Board.Tiles.OfType<Mine>().Where(x => x.Coordinates.x == "1" && x.Coordinates.y == "1");

			foreach (var item in mi)
			{
				Console.WriteLine("Mine position:: (" + item.Coordinates.x + "," + item.Coordinates.y + ")");
			}
		}

		private void SetExit(string exitPoint)
		{

			Board.Tiles.Add(new Exit { Coordinates = new Coordinates { x = "", y = "" } });
			//todo: what if a exit is out of bounds?
			// will always have to be less that the board size.
			throw new NotImplementedException();
		}
		
		private void SetTurtle(string v)
		{
			//todo: what if turtle is out of bounds?
			// will always have to be less that the board size.
		}

		public void Play() { }

		public string Result() { return ""; }
	}
}
