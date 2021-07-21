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
		public char Orientation { get; set; }

		public void Move()
		{
			// When the first direction is M, turtle continues to the given orientation.
			if (Orientation.Equals(north))
			{
				Coordinates.x -= 1;
			}

			if (Orientation.Equals(south))
			{
				Coordinates.x += 1;
			}

			if (Orientation.Equals(east))
			{
				Coordinates.y += 1;
			}

			if (Orientation.Equals(west))
			{
				Coordinates.y -= 1;
			}

			PrintCoordinates();
		}

		public void Rotate(char direction)
		{
			if (Orientation.Equals(north) && direction.Equals(right) ||
					Orientation.Equals(south) && direction.Equals(left))
			{
				Orientation = east;
			}
			else if (Orientation.Equals(north) && direction.Equals(left) ||
				Orientation.Equals(south) && direction.Equals(right))
			{
				Orientation = west;
			}
			else if (Orientation.Equals(east) && direction.Equals(right) ||
				Orientation.Equals(west) && direction.Equals(left))
			{
				Orientation = south;
			}
			else if (Orientation.Equals(east) && direction.Equals(left) ||
				Orientation.Equals(west) && direction.Equals(right))
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
