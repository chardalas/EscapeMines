using System.Collections.Generic;

namespace EscapeMinesChardalasEmmanouil
{
	interface IBoard
	{
		string Size { get; set; }
		List<ITile> Tiles { get; set; }

		void SetSize();
	}
}
