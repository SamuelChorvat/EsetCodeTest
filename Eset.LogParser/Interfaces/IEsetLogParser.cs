namespace Eset.LogParser.Interfaces
{
    public interface IEsetLogParser
    {
        public void ParseLogFile(string fileName, TextWriter textWriter);
    }
}