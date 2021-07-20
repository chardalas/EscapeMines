using System;
using System.Text;

namespace BoardGameChardalasEmmanouil
{
	class Turtle : IPawn
	{
		private string north = "N";
		private string south = "S";
		private string east = "E";
		private string west = "W";
		private string right = "R";
		private string left = "L";

		public Coordinates Coordinates { get; set; }
		public string Orientation { get; set; } // think about making it char type		
				
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

		public void Rotate(string direction)
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
