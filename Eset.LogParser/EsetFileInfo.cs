using System.Text.RegularExpressions;
using Eset.LogParser.Interfaces;

namespace Eset.LogParser
{
    public class EsetFileInfo : IEsetFileInfo
    {
        public string Name { get; set; }
        public HashSet<string> Threats { get; }
        public HashSet<string> Packers { get; }

        public EsetFileInfo()
        {
            Name = string.Empty;
            Threats = new HashSet<string>();
            Packers = new HashSet<string>();
        }

        public bool IsInfected()
        {
            return Threats.Where(x => !x.Equals("is OK") && !x.Equals("")).ToList().Count > 0;
        }

        public string GetFormattedFileInfoString()
        {
            return $"FILE -> {Name}\n"
                        + $"\tARCHIVE -> {Packers.Count > 0}\n"
                        + (Packers.Count > 0 ? $"\tPACKERS -> {string.Join(", ", Packers)}\n" : "")
                        + $"\tINFILTRATIONS -> {string.Join(", ", Threats.Where(x => !x.Equals("multiple threats") && !x.Equals("is OK") && !x.Equals("")))}";
        }
    }
}
