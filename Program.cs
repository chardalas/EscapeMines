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

                if (settings != null && !settings.Any()) { Console.Write("\nNo settings were found for file: {0}.\n", gameSettings); Console.ReadLine(); return; }

                IEscapeMinesSettingsValidator emsv = new EscapeMinesSettingsValidator
                {
                    Settings = settings.ToList()
                };

                if (emsv.ValidateBoardSize(emsv.Settings[0]) ||
                emsv.ValidateMines(emsv.Settings[1]) ||
                emsv.ValidateExitPoint(emsv.Settings[2]) ||
                emsv.ValidateStartingPoint(emsv.Settings[3]) ||
                emsv.ValidateMovesSets(emsv.Settings.Skip(4).Take(emsv.Settings.Count())))
                { Console.ReadLine(); return; }

                var gameName = gameSettings.Split('\\');
                Console.Write("\n------------ New game is started for file: {0} ------------\n", gameName[gameName.Length - 1]);

                // Let the game begin!
                IBoardGame em = new EscapeMines();

                em.SetupBoard(emsv.SanitizedSettings.Take(4).ToList());

                var movesSets = emsv.SanitizedSettings.Skip(4).Take(emsv.SanitizedSettings.Count());

                foreach (
                    var movesSet in movesSets)
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
