using Eset.LogParser.Interfaces;

namespace Eset.LogParser
{
    public class EsetFileOpener : IEsetFileOpener
    {
        public StreamReader OpenFile(string fileName)
        {
            return File.OpenText(GetFilePath(fileName));
        }

        private string GetFilePath(string fileName)
        {
            if (Environment.CurrentDirectory.EndsWith("net7.0"))
            {
                // Running in <project>\bin\<Debug|Release>\net7.0
                return Path.Combine("..", "..", "..", "..", fileName);
            }
            else
            {
                // Running in <project>
                return Path.Combine("..", fileName);
            }
        }
    }
}
