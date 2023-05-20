using System.Text.RegularExpressions;
using Eset.LogParser.Interfaces;

namespace Eset.LogParser
{
    public class EsetLogParserHelper : IEsetLogParserHelper
    {
        public ICollection<string> GetLogLineFieldValues(string logLine)
        {
            string pattern = @$"name=""(.*?)"", threat=""(.*?)"", action=""(.*?)"", info=""(.*?)""";
            return Regex.Match(logLine, pattern).Groups.Cast<Group>().Skip(1).Select(group => group.Value).ToList();
        }

        public bool IsValidLogLine(string logLine)
        {
            return logLine.StartsWith("name=");
        }

        public bool IsNewParentFile(string newName, string currentName)
        {
            return currentName.Equals(string.Empty) || !newName.StartsWith($"{currentName} »");
        }

        public bool HasPacker(string previousNameFieldValue, string currentNameFieldValue)
        {
            return !previousNameFieldValue.Equals(string.Empty) 
                && (currentNameFieldValue.Split(" » ").Length - previousNameFieldValue.Split(" » ").Length == 2);
        }

        public string GetPacker(string currentNameFieldValue)
        {
            return currentNameFieldValue.Split(" » ")[^2];
        }
    }
}
