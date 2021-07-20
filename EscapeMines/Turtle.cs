using System;
using System.Text;

namespace BoardGameChardalasEmmanouil
{
    class Turtle : IPawn
    {
        private string north = "N";
        private string south = "S";
        private string east = "E";
        private string west = "W";
        public Coordinates Coordinates { get; set; }
        public string Orientation { get; set; } // think about making it char type
        public StringBuilder Rotation { get; set; }        

        public Turtle()
        {
            this.Rotation = new StringBuilder();
        }

        public void Move()
        {
            SetOrientation();

            // When the first direction is M, turtle continues straight to the given orientation.
            if (Orientation == "N")
            {
                Coordinates.x -= 1;
            }

            if (Orientation == "S")
            {
                Coordinates.x += 1;
            }

            if (Orientation == "E")
            {
                Coordinates.y += 1;
            }

            if (Orientation == "W")
            {
                Coordinates.y -= 1;
            }
            
            GetPosition();            
        }

        private void SetOrientation()
        {
            for (int i = 0; i < Rotation.Length; i++)
            {
                if (Orientation == "N" && Rotation[i] == 'R' ||
                    Orientation == "S" && Rotation[i] == 'L')
                {
                    Orientation = east;
                    continue;
                }

                if (Orientation == "N" && Rotation[i] == 'L' ||
                    Orientation == "S" && Rotation[i] == 'R')
                {
                    Orientation = west;
                    continue;
                }

                if (Orientation == "E" && Rotation[i] == 'R' ||
                    Orientation == "W" && Rotation[i] == 'L')
                {
                    Orientation = south;
                    continue;
                }

                if (Orientation == "E" && Rotation[i] == 'L' ||
                    Orientation == "W" && Rotation[i] == 'R')
                {
                    Orientation = north;
                    continue;
                }
            }

            Rotation.Clear();
        }

        void GetPosition()
        {
            Console.WriteLine("Turtle is heading to: ({0},{1}) {2}", Coordinates.x, Coordinates.y, Orientation);
        }
    }
}
