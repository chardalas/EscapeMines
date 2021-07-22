using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BoardGameChardalasEmmanouil
{
    public class EscapeMinesSettingsLoader : IGameSettingsLoader
    {
        private string settingsDirectory;
        private string currentDirectory;

        public List<string> SanitizedSettings { get; }
        public string SettingsDirectory { set => settingsDirectory = value; }

        public EscapeMinesSettingsLoader()
        {
            currentDirectory = Environment.CurrentDirectory;
            SanitizedSettings = new List<string>();
        }

        public IEnumerable<string> Load()
        {
            string settingsDirectoryFullPath = Path.Combine(Directory.GetParent(currentDirectory).Parent.FullName, settingsDirectory);

            return from file in Directory.EnumerateFiles(settingsDirectoryFullPath, "*.txt") select file;
        }      
    }
}
