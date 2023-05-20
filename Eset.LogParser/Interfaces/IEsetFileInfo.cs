namespace Eset.LogParser.Interfaces
{
    public interface IEsetFileInfo
    {
        string Name { get; set; }
        HashSet<string> Threats { get; }
        HashSet<string> Packers { get; }
        bool IsInfected();
        string GetFormattedFileInfoString();
    }
}
