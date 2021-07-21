using System;
using System.Text;

namespace BoardGameChardalasEmmanouil
{
	class Turtle : IPawn
	{
		private char north = 'N';
		private char south = 'S';
		private char east = 'E';
		private char west = 'W';
		private char right = 'R';
		private char left = 'L';

		public Coordinates Coordinates { get; set; }
		public char Orientation { get; set; } // think about making it char type		

		public void Move()
		{
			// When the first direction is M, turtle continues to the given orientation.
			if (Orientation == north)
			{
				Coordinates.x -= 1;
			}

			if (Orientation == south)
			{
				Coordinates.x += 1;
			}

			if (Orientation == east)
			{
				Coordinates.y += 1;
			}

			if (Orientation == west)
			{
				Coordinates.y -= 1;
			}

			PrintCoordinates();
		}

		public void Rotate(char direction)
		{
			if (Orientation == north && direction == right ||
					Orientation == south && direction == left)
			{
				Orientation = east;
			}
			else if (Orientation == north && direction == left ||
				Orientation == south && direction == right)
			{
				Orientation = west;
			}
			else if (Orientation == east && direction == right ||
				Orientation == west && direction == left)
			{
				Orientation = south;
			}
			else if (Orientation == east && direction == left ||
				Orientation == west && direction == right)
			{
				Orientation = north;
			}
		}

		private void PrintCoordinates()
		{
			Console.WriteLine("Turtle is heading {0} to tile: ({1},{2})", Orientation, Coordinates.x, Coordinates.y);
		}
	}
}
