using Plugin.Logger.Abstractions;
using System;

namespace Plugin.Logger
{
    /// <summary>
    /// Implementation for Logger
    /// </summary>
    public class LoggerImplementation : LoggerBase
    {
        public override bool AppendToFile(string filename, string message)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteFile(string filename)
        {
            throw new NotImplementedException();
        }

        public override long GetFileSizeKb(string fileName)
        {
            throw new NotImplementedException();
        }

        public override string GetNextAvailableFileName(string logFileNameBase)
        {
            throw new NotImplementedException();
        }

        public override string LoadFromFile(string filename)
        {
            throw new NotImplementedException();
        }

        public override bool SaveToFile(string filename, string message)
        {
            throw new NotImplementedException();
        }
    }
}