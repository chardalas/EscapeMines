namespace BoardGameChardalasEmmanouil
{
	interface IPawn
	{
		Coordinates Coordinates { get; set; }

		void Move();
		void Rotate();
	}
}
