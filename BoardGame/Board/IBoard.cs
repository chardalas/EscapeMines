using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
    public interface IBoard
    {
        int Width { get; set; }
        int Length { get; set; }
        List<ITile> Tiles { get; set; }

        void Print();
        void CreateTiles();
        int GetTileIndex(int x, int y);
    }
}
