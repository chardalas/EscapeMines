namespace EscapeMinesChardalasEmmanouil
{
	interface IBoard
	{
		int Length { get; set; }
		int Width { get; set; }
		
		void SetSize();
	}
}
