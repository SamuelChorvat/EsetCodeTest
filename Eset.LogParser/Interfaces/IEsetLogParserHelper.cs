namespace Eset.LogParser.Interfaces
{
    public interface IEsetLogParserHelper
    {
        public ICollection<string> GetLogLineFieldValues(string logLine);
        public bool IsValidLogLine(string logLine);
        public bool IsNewParentFile(string newName, string currentName);
        public bool HasPacker(string previousNameFieldValue, string currentNameFieldValue);
        public string GetPacker(string currentNameFieldValue);
    }
}
