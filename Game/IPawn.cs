namespace EscapeMinesChardalasEmmanouil
{
	interface IPawn
	{
		Coordinates Position { get; set; }

		void Move();
		void Rotate();
	}
}
