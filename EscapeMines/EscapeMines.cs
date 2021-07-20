using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGameChardalasEmmanouil
{
	class EscapeMines : IBoardGame
	{
		private string[] directions;
		private string startingPoint1;

		public IBoard Board { get; }
		public List<IPawn> Pawns { get; }

		public EscapeMines()
		{
			this.Board = new EscapeMinesBoard(); // Board (list of tiles) is created.
			this.Pawns = new List<IPawn>();
		}

		public void SetupBoard(List<string> settings)
		{
			// var tri= Regex.Replace(settings.FirstOrDefault(), @"\s+", "");
			// todo: validate input

			// Execute settings one after the other.
			SetupTiles(settings[0]);
			SetupMines(settings[1]);
			SetupExit(settings[2]);
			SetupTurtle(settings[3]);

			// Board.Print();			
		}

		public void Play(string movesSet)
		{
			var turtle = Pawns[0];
			directions = movesSet.Trim().Split(' ');

			foreach (var direction in directions)
			{
				if (direction.Contains("R") || direction.Contains("L"))
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

		private void SetupDirections(List<string> input)
		{
			foreach (var item in input)
			{
				//directions.Add( item.Trim().Split(' '));
				//	Console.WriteLine(item);
			}
		}

		private void SetupTiles(string input)
		{
			int[] boardDimensions = Array.ConvertAll(input.Trim().Split(' '), int.Parse);

			Board.Length = boardDimensions[0];
			Board.Width = boardDimensions[1];

			Board.CreateTiles();
		}

		private void SetupMines(string input)
		{
			// todo: validate input		
			foreach (var mine in input.Trim().Split(' '))
			{
				int[] points = Array.ConvertAll(mine.Trim().Split(','), int.Parse);

				var tileIndex = Board.GetTileIndex(points[0], points[1]);

				// The bomb has been planted.
				Board.Tiles[tileIndex] = new Mine { Coordinates = new Coordinates { x = points[0], y = points[1] } };
			}
		}

		private void SetupExit(string input)
		{
			// todo: validate input			
			int[] points = Array.ConvertAll(input.Trim().Split(' '), int.Parse);

			var tileIndex = Board.GetTileIndex(points[0], points[1]);

			Board.Tiles[tileIndex] = new Exit { Coordinates = new Coordinates { x = points[0], y = points[1] } };
		}

		private void SetupTurtle(string input)
		{
			startingPoint1 = input;
			// todo: validate input
			var startingPoint = input.Trim().Split(' ');

			// var i3n = input.Trim().ToCharArray();

			int[] points = Array.ConvertAll(startingPoint.Take(startingPoint.Length - 1).ToArray(), int.Parse);

			// Make sure turtle is put on an existing tile.
			Board.GetTileIndex(points[0], points[1]);

			Pawns.Add(new Turtle { Coordinates = new Coordinates { x = points[0], y = points[1] }, Orientation = startingPoint[2] });
		}

		public void ResetTurtle()
		{
			var startingPoint = startingPoint1.Trim().Split(' ');
			int[] points = Array.ConvertAll(startingPoint.Take(startingPoint.Length - 1).ToArray(), int.Parse);
			Pawns[0].Coordinates.x = points[0];
			Pawns[0].Coordinates.y = points[1];
			Pawns[0].Orientation = startingPoint[2];
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
