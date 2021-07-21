using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BoardGameChardalasEmmanouil
{
	class EscapeMines : IBoardGame
	{
		private string[] directions;
		private string[] turtlesStartingPoint;

		public IBoard Board { get; }
		public List<IPawn> Pawns { get; }

		public EscapeMines()
		{
			this.Board = new EscapeMinesBoard(); // Board (list of tiles) is created.
			this.Pawns = new List<IPawn>();
		}

		public void SetupBoard(List<string> settings)
		{
			// Execute settings one after the other.
			SetupTiles(settings[0]);
			SetupMines(settings[1]);
			SetupExit(settings[2]);
			SetupTurtle(settings[3]);
			Board.Print();
		}

		public void Play(string movesSet)
		{
			var turtle = Pawns[0];
			directions = movesSet.Trim().Split(' ');

			foreach (var direction in movesSet)
			{
				if (direction.Equals('R') || direction.Equals('L'))
				{
					turtle.Rotate(direction);
					continue;
				}

				turtle.Move();

				var tileIndex = Board.GetTileIndex(turtle.Coordinates.x, turtle.Coordinates.y);

				if (Board.Tiles[tileIndex].GetType() == typeof(Mine))
				{
					Console.WriteLine("Mine Hit: The turtle was blown up.");
					ResetTurtle();
					return;
				}

				if (Board.Tiles[tileIndex].GetType() == typeof(Exit))
				{
					Console.WriteLine("Success: The turtle crossed the minefield!");
					ResetTurtle();
					return;
				}
			}
			Console.WriteLine("Still in danger: The turtle has not crossed the minefield.");
		}

		public string Result() { return ""; }

		public void PrintGameSettings(List<string> settings)
		{
			Console.WriteLine("New Game Has Started.\n");
			Console.WriteLine("Game Settings:.\n");

			foreach (var setting in settings)
			{
				Console.WriteLine("{0}", setting);
			}
		}

		private void SetupTiles(string input)
		{
			int[] boardDimensions = Array.ConvertAll(input.Split(' '), int.Parse);

			Board.Length = boardDimensions[1];
			Board.Width = boardDimensions[0];

			Board.CreateTiles();
		}

		private void SetupMines(string input)
		{
			var minesCoordinates = input.Remove(input.Length - 1).Split(' ');

			foreach (var mineCoordinates in minesCoordinates)
			{
				int[] points = Array.ConvertAll(mineCoordinates.Split(','), int.Parse);

				var tileIndex = Board.GetTileIndex(points[0], points[1]);

				// The bomb has been planted.
				Board.Tiles[tileIndex] = new Mine { Coordinates = new Coordinates { x = points[0], y = points[1] } };
			}
		}

		private void SetupExit(string input)
		{
			int[] points = Array.ConvertAll(input.Split(' '), int.Parse);

			var tileIndex = Board.GetTileIndex(points[0], points[1]);

			Board.Tiles[tileIndex] = new Exit { Coordinates = new Coordinates { x = points[0], y = points[1] } };
		}

		private void SetupTurtle(string input)
		{
			var startingPoint = turtlesStartingPoint = input.Split(' ');

			// Leading zeros are dropped upon conversion.
			int[] points = Array.ConvertAll(startingPoint.Take(startingPoint.Length - 1).ToArray(), int.Parse);

			// Make sure turtle is put on an existing tile.
			Board.GetTileIndex(points[0], points[1]);

			Pawns.Add(new Turtle { Coordinates = new Coordinates { x = points[0], y = points[1] }, Orientation = Convert.ToChar(startingPoint[2]) });
		}

		public void ResetTurtle()
		{
			int[] points = Array.ConvertAll(turtlesStartingPoint.Take(turtlesStartingPoint.Length - 1).ToArray(), int.Parse);

			Pawns[0].Coordinates.x = points[0];
			Pawns[0].Coordinates.y = points[1];
			Pawns[0].Orientation = Convert.ToChar(turtlesStartingPoint[2]);
		}
	}
}
