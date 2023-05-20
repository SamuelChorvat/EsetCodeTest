using Eset.LogParser.Interfaces;

namespace Eset.LogParser
{
    public class EsetLogParser : IEsetLogParser
    {
        private readonly IEsetFileOpener _esetFileOpener;
        private readonly IEsetFileInfo _esetFileInfo;
        private readonly IEsetLogParserHelper _esetLogParserHelper;

        public EsetLogParser(IEsetFileOpener esetFileOpener, IEsetFileInfo esetFileInfo, IEsetLogParserHelper esetLogParserHelper)
        {
            _esetFileOpener = esetFileOpener;
            _esetFileInfo = esetFileInfo;
            _esetLogParserHelper = esetLogParserHelper;
        }

        public void ParseLogFile(string fileName, TextWriter textWriter)
        {
            using (StreamReader streamReader = _esetFileOpener.OpenFile(fileName))
            {
                string previousNameFieldValue = string.Empty;
                string? currentLogLine = string.Empty;
                while ((currentLogLine = streamReader.ReadLine()) != null)
                {
                    if (!_esetLogParserHelper.IsValidLogLine(currentLogLine)) continue;
                    List<string> fieldValues = (List<string>)_esetLogParserHelper.GetLogLineFieldValues(currentLogLine);

                    if (_esetLogParserHelper.IsNewParentFile(fieldValues[0], _esetFileInfo.Name))
                    {
                        if (_esetFileInfo.IsInfected()) textWriter.WriteLine(_esetFileInfo.GetFormattedFileInfoString());
                        _esetFileInfo.Packers.Clear();
                        _esetFileInfo.Threats.Clear();
                        _esetFileInfo.Name = fieldValues[0];
                    }

                    if (_esetLogParserHelper.HasPacker(previousNameFieldValue, fieldValues[0]))
                    {
                        _esetFileInfo.Packers.Add(_esetLogParserHelper.GetPacker(fieldValues[0]));
                    }

                    _esetFileInfo.Threats.Add(fieldValues[1]);

                    previousNameFieldValue = fieldValues[0];
                }
                if (_esetFileInfo.IsInfected()) textWriter.WriteLine(_esetFileInfo.GetFormattedFileInfoString());
            }
        }
    }
}
