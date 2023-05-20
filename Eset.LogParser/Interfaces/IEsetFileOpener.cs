namespace Eset.LogParser.Interfaces
{
    public interface IEsetFileOpener
    {
        StreamReader OpenFile(string fileName);
    }
}
