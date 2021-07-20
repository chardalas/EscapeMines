﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGameChardalasEmmanouil
{
    class EscapeMines : IBoardGame
    {
        private string[] directions;
        public IBoard Board { get; }
        public List<IPawn> Pawns { get; }

        public EscapeMines()
        {
            this.Board = new EscapeMinesBoard(); // Board (list of tiles) is created.
            this.Pawns = new List<IPawn>();
        }

        public void SetupBoard(IEnumerable<string> settings)
        {
            // var tri= Regex.Replace(settings.FirstOrDefault(), @"\s+", "");
            // todo: validate input

            // Execute settings one after the other.
            SetupBoardSize(settings.First());
            Board.CreateTiles();
            SetupMines(settings.Skip(1).First());
            SetupExit(settings.Skip(2).First());
            SetupTurtle(settings.Skip(3).First());
            SetupDirections(settings.Skip(4).First());
            Board.Print();
            // PrintMines();
            // PrintPawns();
        }

        public void Play()
        {
            var turtle = Pawns[0];

            foreach (var direction in directions)
            {
                if (direction.Contains("R") || direction.Contains("L"))
                {
                    turtle.Rotate(direction);                    
                    continue;
                }

                turtle.Move();

                var tileIndex = Board.GetTileIndex(turtle.Coordinates.x, turtle.Coordinates.y);

                if (Board.Tiles[tileIndex].GetType() == typeof(Mine))
                {
                    Console.WriteLine("The turtle hit a mine, try again.");
                    return;
                }

                if (Board.Tiles[tileIndex].GetType() == typeof(Exit))
                {
                    Console.WriteLine("The turtle successfully crossed the minefield!");
                    return;
                }
            }
        }

        public string Result() { return ""; }

        private void SetupDirections(string input)
        {
            directions = input.Trim().Split(' ');
        }

        private void SetupBoardSize(string input)
        {
            int[] boardDimensions = Array.ConvertAll(input.Trim().Split(' '), int.Parse);

            Board.Width = boardDimensions[0];
            Board.Length = boardDimensions[1];
        }

        private void SetupMines(string input)
        {
            // todo: validate input		
            foreach (var mine in input.Trim().Split(' '))
            {
                int[] points = Array.ConvertAll(mine.Trim().Split(','), int.Parse);

                var tileIndex = Board.GetTileIndex(points[0], points[1]);

                // The bomb has been planted.
                Board.Tiles[tileIndex] = new Mine { Coordinates = new Coordinates { x = points[0], y = points[1] } };
            }      
        }

        private void SetupExit(string input)
        {
            // todo: validate input			
            int[] points = Array.ConvertAll(input.Trim().Split(' '), int.Parse);

            var tileIndex = Board.GetTileIndex(points[0], points[1]);

            Board.Tiles[tileIndex] = new Exit { Coordinates = new Coordinates { x = points[0], y = points[1] } };
        }

        private void SetupTurtle(string input)
        {
            // todo: validate input			
            var inputArr = input.Trim().Split(' ');

            // var i3n = input.Trim().ToCharArray();

            int[] points = Array.ConvertAll(inputArr.Take(inputArr.Length - 1).ToArray(), int.Parse);

            // Make sure turtle is put on an existing tile.
            Board.GetTileIndex(points[0], points[1]);

            Pawns.Add(new Turtle { Coordinates = new Coordinates { x = points[0], y = points[1] }, Orientation = inputArr[2] });
        }

        private void PrintPawns()
        {
            foreach (var item in Pawns)
            {
                Console.WriteLine("Pawn:: " + item.Coordinates.x + " " + item.Coordinates.y + " " + item.Orientation + "\n");
            }
        }

        private void PrintMines()
        {
            foreach (var item in Board.Tiles.OfType<Mine>())
            {
                Console.WriteLine("Mine:: " + item.Coordinates.x + " " + item.Coordinates.y + "\n");
            }
        }
    }
}
