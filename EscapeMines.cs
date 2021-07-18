using System;
using System.IO;
using System.Linq;

namespace EscapeMinesChardalasEmmanouil
{
	class EscapeMines : IBoardGame
	{
		private IBoard board;
		private string currentDirectory;
		private string gamesDirectory;

		public EscapeMines()
		{
			this.currentDirectory = Environment.CurrentDirectory;
			this.gamesDirectory = Path.Combine(Directory.GetParent(currentDirectory).Parent.FullName, @"EscapeMinesInputs\");
		}

		public void SetupBoard()
		{
			board.Length = 2;
			board.Width = 4;
		}

		public void Play() { }

		public string Result() { return ""; }
	}
}
