namespace BoardGameChardalasEmmanouil
{
	class Tile : ITile
	{
		public Coordinates Position { get; set; }
	}

	class Mine : ITile
	{
		public Coordinates Position { get; set; }
	}

	class Exit : ITile
	{
		public Coordinates Position { get; set; }
	}
}
