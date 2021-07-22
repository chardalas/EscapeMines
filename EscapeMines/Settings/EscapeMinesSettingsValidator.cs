using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BoardGameChardalasEmmanouil
{
    public class EscapeMinesSettingsValidator : IEscapeMinesSettingsValidator
    {
        public List<string> Settings { get; set; }
        public List<string> SanitizedSettings { get; }

        public EscapeMinesSettingsValidator()
        {
            Settings = new List<string>();
            SanitizedSettings = new List<string>();
        }

        public bool ValidateBoardSize(string input)
        {
            //ValidatePoint(Settings[0]);
            //string input = Settings[0];
            Regex boardSize = new Regex(@"^[0-9]+ [0-9]+");

            if (string.IsNullOrEmpty(input) || ValidateNonZeroMatrix(input) || !boardSize.IsMatch(input))
            {
                Console.WriteLine("\nInvalid input: {0}", input);
                Console.WriteLine("Settings require an input that begins with two numbers, greater than zero and separated by space: 1 2");

                return true;
            }

            SanitizedSettings.Add(boardSize.Match(input).Value);

            return false;
        }

        public bool ValidateMines(string input)
        {
            //string input = Settings[1];
            Regex mines = new Regex(@"([0-9]+(,[0-9]+))");

            if (string.IsNullOrEmpty(input) || !mines.IsMatch(input))
            {
                Console.WriteLine("\nInvalid input: {0}", input);
                Console.WriteLine("Settings require two numbers separated by comma: 1,2");

                return true;
            }

            StringBuilder matches = new StringBuilder();

            foreach (Match match in mines.Matches(input))
            {
                if (match.Length > 0)
                {
                    matches.Append(match).Append(" ");
                }
            }

            SanitizedSettings.Add(matches.ToString());

            return false;
        }

        public bool ValidateExitPoint(string input)
        {
            //ValidatePoint(Settings[2]);
            //string input = Settings[2];
            Regex boardSize = new Regex(@"^[0-9]+ [0-9]+");

            if (string.IsNullOrEmpty(input) || !boardSize.IsMatch(input))
            {
                Console.WriteLine("\nInvalid input: {0}", input);
                Console.WriteLine("Settings require an input that begins with two numbers separated by space: 1 2");

                return true;
            }

            SanitizedSettings.Add(boardSize.Match(input).Value);

            return false;
        }

        public bool ValidateStartingPoint(string input)
        {
            //string input = Settings[3];
            Regex startingPoint = new Regex(@"([0-9]+ [0-9]+) [NSEW]");

            if (string.IsNullOrEmpty(input) || !startingPoint.IsMatch(input))
            {
                Console.WriteLine("\nInvalid input: {0}", input);
                Console.WriteLine("Settings require an input that begins with two numbers separated by space followed by a char [NSEW]: 1 2 E");

                return true;
            }

            SanitizedSettings.Add(startingPoint.Match(input).Value);

            return false;
        }

        public bool ValidateMovesSets(IEnumerable<string> movesSets)
        {
            //var movesSets = Settings.Skip(4).Take(Settings.Count());
            if (!movesSets.Any())
            {
                Console.WriteLine("\nInvalid input: A sequence of moves is required.\n");
                return true;
            }

            Regex moves = new Regex(@"[^LRM]");

            foreach (var movesSet in movesSets)
            {
                SanitizedSettings.Add(moves.Replace(movesSet, string.Empty));
            }

            return false;
        }

        public bool ValidateNonZeroMatrix(string input)
        {
            //            string input = Settings[0];
            Regex boardSize = new Regex(@"0 0");

            if (string.IsNullOrEmpty(input) || boardSize.IsMatch(input))
            {
                return true;
            }

            return false;
        }

        private bool ValidatePoint(string input)
        {
            Regex boardSize = new Regex(@"^[0-9]+ [0-9]+");

            if (string.IsNullOrEmpty(input) || !boardSize.IsMatch(input))
            {
                Console.WriteLine("\nInvalid input: {0}", input);
                Console.WriteLine("Settings require an input that begins with two numbers separated by space: 1 2");

                return true;
            }

            SanitizedSettings.Add(boardSize.Match(input).Value);

            return false;
        }
    }
}
