using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BoardGameChardalasEmmanouil
{
    public class EscapeMines : IBoardGame
    {
        private string[] directions;
        private string[] turtlesStartingPoint;
        private string result;

        public IBoard Board { get; }
        public List<IPawn> Pawns { get; }
        public string Result { get { return result; } }

        public EscapeMines()
        {
            this.Board = new EscapeMinesBoard(); // Board (list of tiles) is created.
            this.Pawns = new List<IPawn>();
        }

        public void SetupBoard(List<string> settings)
        {
            // Execute settings one after the other.
            SetupTiles(settings[0]);
            SetupMines(settings[1]);
            SetupExit(settings[2]);
            SetupTurtle(settings[3]);
            //Board.Print();
        }

        public void Play(string movesSet)
        {
            var turtle = Pawns[0];

            directions = movesSet.Trim().Split(' ');

            foreach (var direction in movesSet)
            {
                if (direction.Equals('R') || direction.Equals('L'))
                {
                    turtle.Rotate(direction);
                    continue;
                }

                turtle.Move();

                var endOfGame = CalculateMove();

                if (endOfGame) { return; }
            }
        }

        private void SetupTiles(string input)
        {
            int[] boardDimensions = Array.ConvertAll(input.Split(' '), int.Parse);

            Board.Length = boardDimensions[1];
            Board.Width = boardDimensions[0];

            Board.CreateTiles();
        }

        private void SetupMines(string input)
        {
            var minesCoordinates = input.Remove(input.Length - 1).Split(' ');

            foreach (var mineCoordinates in minesCoordinates)
            {
                int[] points = Array.ConvertAll(mineCoordinates.Split(','), int.Parse);

                var tileIndex = Board.GetTileIndex(points[0], points[1]);

                Boundaries(tileIndex, points);

                // The bomb has been planted.
                Board.Tiles[tileIndex] = new Mine { Coordinates = new Coordinates { x = points[0], y = points[1] } };
            }
        }

        private void SetupExit(string input)
        {
            int[] points = Array.ConvertAll(input.Split(' '), int.Parse);

            var tileIndex = Board.GetTileIndex(points[0], points[1]);

            Boundaries(tileIndex, points);

            Board.Tiles[tileIndex] = new Exit { Coordinates = new Coordinates { x = points[0], y = points[1] } };
        }

        private void SetupTurtle(string input)
        {
            var startingPoint = turtlesStartingPoint = input.Split(' ');

            // Leading zeros are dropped upon conversion.
            int[] points = Array.ConvertAll(startingPoint.Take(startingPoint.Length - 1).ToArray(), int.Parse);

            Boundaries(Board.GetTileIndex(points[0], points[1]), points);

            Pawns.Add(new Turtle { Coordinates = new Coordinates { x = points[0], y = points[1] }, Orientation = Convert.ToChar(startingPoint[2]) });
        }

        private bool CalculateMove()
        {
            var turtle = Pawns[0];
            var tileIndex = Board.GetTileIndex(turtle.Coordinates.x, turtle.Coordinates.y);

            if (tileIndex < 0)
            {
                result = "Still in danger: The turtle has not crossed the minefield. :|";
            }
            else if (Board.Tiles[tileIndex].GetType() == typeof(Mine))
            {
                result = "Mine Hit: The turtle was blown up. :(";
            }
            else if (Board.Tiles[tileIndex].GetType() == typeof(Exit))
            {
                result = "Success: The turtle crossed the minefield! :)";
            }
            else { return false; }

            ResetTurtle();

            return true;
        }

        private void ResetTurtle()
        {
            int[] points = Array.ConvertAll(turtlesStartingPoint.Take(turtlesStartingPoint.Length - 1).ToArray(), int.Parse);

            Pawns[0].Coordinates.x = points[0];
            Pawns[0].Coordinates.y = points[1];
            Pawns[0].Orientation = Convert.ToChar(turtlesStartingPoint[2]);
        }

        private void Boundaries(int tileIndex, int[] points)
        {
            // Make sure that all tiles are existing ones, otherwise stop immediately.
            if (tileIndex < 0)
            {
                Console.WriteLine("The tile with coordinates: ({0},{1}) does not exist. Please amend the input and try again.", points[0], points[1]);
                Console.ReadLine();
                Environment.Exit(1);
            }
        }
    }
}
