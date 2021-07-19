namespace BoardGameChardalasEmmanouil
{
	interface IPawn
	{
		Coordinates Position { get; set; }

		void Move();
		void Rotate();
	}
}
