using System.Collections.Generic;
using System.Linq;

namespace BoardGameChardalasEmmanouil
{
	class EscapeMines : IBoardGame
	{
		public IBoard Board { get; }
		public IPawn Turtle { get; }

		public EscapeMines()
		{
			this.Board = new EscapeMinesBoard();
			this.Turtle = new Turtle();
		}

		public void SetupBoard(IEnumerable<string> settings)
		{
			Board.Size = settings.FirstOrDefault();
			//Board.Tiles.Add(new Mine { Position = new Coordinates { x = 1, y = 2 } });
			//Board.Tiles.Add(new Exit { Position = new Coordinates { x = 1, y = 3 } });
			//Board.Tiles.Add(new Turtle { Position = new Coordinates { x = 1, y = 3 } });

			// em.Board.Size = 4 5;
			// em.Mines.Potition = 1,0 1,2 3,4;
			// em.Exit.Potition = 1,0 1,2 3,4;
			// em.Turtle.Potition = 1 0 N;
		}

		public void Play() { }

		public string Result() { return ""; }
	}
}
