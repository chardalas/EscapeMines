using System;
using System.IO;
using System.Linq;

namespace BoardGameChardalasEmmanouil
{
    class Program
    {  
        static void Main(string[] args)
        {
            IGameSettingsLoader ems = new EscapeMinesSettingsLoader
            {
                SettingsDirectory = @"Inputs\"
            };

            var gamesSettings = ems.Load();

            if (gamesSettings != null && !gamesSettings.Any()) { Console.Write("No file settings were found."); Console.ReadLine(); return; }

            Console.WriteLine("Welcome to the Escape Mines.");

            foreach (var gameSettings in gamesSettings)
            {
                var settings = File.ReadLines(gameSettings);

                if (!settings.Any()) { Console.Write("\nNo settings were found.\n"); return; }

                IEscapeMinesSettingsValidator emsv = new EscapeMinesSettingsValidator
                {
                    Settings = settings.ToList()
                };

                if (emsv.ValidateNonZeroMatrix() ||
                emsv.ValidateBoardSize() ||
                emsv.ValidateMines() ||
                emsv.ValidateExitPoint() ||
                emsv.ValidateStartingPoint() ||
                emsv.ValidateMovesSets())
                { Console.ReadLine(); return; }
              
                Console.Write("\n-------------------- New game is started --------------------\n");

                IBoardGame em = new EscapeMines();

                em.SetupBoard(emsv.SanitizedSettings.Take(4).ToList());

                var movesSets = emsv.SanitizedSettings.Skip(4).Take(emsv.SanitizedSettings.Count());

                foreach (var movesSet in movesSets)
                {
                    Console.Write("\nPlaying moves:\n");
                    em.Play(movesSet);
                    Console.Write(em.Result);
                    Console.ReadLine();
                }
            }
            Console.ReadLine();
        }
    }
}
