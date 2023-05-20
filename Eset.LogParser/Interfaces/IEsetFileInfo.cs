namespace Eset.LogParser.Interfaces
{
    public interface IEsetFileInfo
    {
        string Name { get; set; }
        ISet<string> Threats { get; }
        ISet<string> Packers { get; }
        bool IsInfected();
        string GetFormattedFileInfoString();
    }
}
