using System;
using System.IO;
using System.Linq;

namespace BoardGameChardalasEmmanouil
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Escape Mines.\n");

            IGameSettingsReader gsr = new GameSettingsReader
            {
                SettingsDirectory = @"Inputs\"
            };

            var gamesSettings = gsr.ReadSettings();

            // if gamesSettings != null && gamesSettings.Any() { Print"No settings were found."}

            foreach (var gameSettings in gamesSettings)
            {
                // you can say that you did some benchmarking and eventually, File.ReadLines was faster.
                var settings = File.ReadLines(gameSettings);

                IBoardGame em = new EscapeMines();
                //em.Board.Length = 1;
                em.Board.Size = "4 5";
                // em.Mines.Potition = 1,0 1,2 3,4;
                // em.Exit.Potition = 1,0 1,2 3,4;
                // em.Turtle.Potition = 1 0 N;
                em.SetupBoard(settings);

                //em
                Console.WriteLine(settings.First());
                Console.WriteLine(settings.Skip(1).First());
                Console.WriteLine(settings.Skip(2).First());
                Console.WriteLine(settings.Skip(3).First());
                Console.WriteLine(settings.Skip(4).FirstOrDefault());
                Console.WriteLine("\nNew Game Has Started.\n");
                Console.ReadLine();

                em.Play(); // em.Moves = R M L M M R M M M;
                em.Result();
                //em.End();

            }
            Console.ReadKey();



            //output
            // either success or failure
            // if the turtle does not reach the exit or doesn't hit a mine.
        }
    }
}
