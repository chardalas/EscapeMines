using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
    class EscapeMinesBoard : IBoard
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public string Size { get; set; }
        public string Exit { get; set; }
        public string Mines { get; set; }
        public List<ITile> Tiles { get; set; }


        public EscapeMinesBoard()
        {
            this.Tiles = new List<ITile>();
        }
                
        public void CreateBoard() { }

        public void SetSize() { }

        void SetMines() { }

        void SetStartingPoint() { }

        void SetExitPoint() { }
    }
}
