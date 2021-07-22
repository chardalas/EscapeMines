using System;
using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
    public class EscapeMinesBoard : IBoard
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public List<ITile> Tiles { get; set; }

        public EscapeMinesBoard()
        {
            this.Tiles = new List<ITile>();
        }

        public void CreateTiles()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Tiles.Add(new Tile { Coordinates = new Coordinates { x = i, y = j } });
                }
            }
        }

        public int GetTileIndex(int x, int y)
        {
            var index = Tiles.FindIndex(t => t.Coordinates.x == x && t.Coordinates.y == y);

            return index;
        }

        public void Print()
        {
            foreach (var item in Tiles)
            {
                Console.WriteLine("Tile:: " + item + " x:: " + item.Coordinates.x + " y:: " + item.Coordinates.y + "\n");
            }
        }
    }
}
