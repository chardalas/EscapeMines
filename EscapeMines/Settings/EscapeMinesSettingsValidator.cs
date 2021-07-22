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
            Regex boardSize = new Regex(@"^[1-9][0-9]* [1-9][0-9]*");

            if (boardSize.IsMatch(input))
            {
                SanitizedSettings.Add(boardSize.Match(input).Value);

                return false;
            }

            Console.WriteLine("\nInvalid input: {0}", input);
            Console.WriteLine("Settings require an input that begins with two numbers, greater than zero and separated by space: 1 2");

            return true;
        }

        public bool ValidateMines(string input)
        {         
            Regex mines = new Regex(@"[0-9]+(,[0-9]+)");

            if (mines.IsMatch(input))
            {
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

            Console.WriteLine("\nInvalid input: {0}", input);
            Console.WriteLine("Settings require two numbers separated by comma: 1,2");

            return true;
        }

        public bool ValidateExitPoint(string input)
        {         
            Regex boardSize = new Regex(@"^[0-9]+ [0-9]+");

            if (boardSize.IsMatch(input))
            {
                SanitizedSettings.Add(boardSize.Match(input).Value);

                return false;
            }

            Console.WriteLine("\nInvalid input: {0}", input);
            Console.WriteLine("Settings require an input that begins with two numbers separated by space: 1 2");

            return true;
        }

        public bool ValidateStartingPoint(string input)
        {         
            Regex startingPoint = new Regex(@"([0-9]+ [0-9]+) [NSEW]");

            if (startingPoint.IsMatch(input))
            {
                SanitizedSettings.Add(startingPoint.Match(input).Value);

                return false;
            }

            Console.WriteLine("\nInvalid input: {0}", input);
            Console.WriteLine("Settings require an input that begins with two numbers separated by space followed by a char [NSEW]: 1 2 E");

            return true;
        }

        public bool ValidateMovesSets(IEnumerable<string> movesSets)
        {         
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
    }
}
