namespace EscapeMinesChardalasEmmanouil
{
	class EscapeMinesBoard : IBoard
	{
		public int Length { get; set; }
		public int Width { get; set; }

		public void SetSize() { }

		void SetMines() { }
		
		void SetStartingPoint() { }
		
		void SetExitPoint() { }

		// check with a collection if you can set a predifiened size
	}
}
