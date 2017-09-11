using Plugin.Logger.Abstractions;
using System;
using System.IO;

namespace Plugin.Logger
{
  /// <summary>
  /// Implementation for Logger
  /// </summary>
  public class LoggerImplementation : LoggerBase
  {
        private string accomplishPath(string fileOrSubfolderName)
        {
            var localFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            return Path.Combine(localFolder, fileOrSubfolderName);
        }

        /// <summary>
        /// To append the log to a file available
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public override bool AppendToFile(string filename, string message)
        {
            try
            {
                var fullPath = accomplishPath(filename);
                File.AppendAllText(fullPath, message + "\r\n");
                return true;
            }
            catch (System.IO.IOException ex)
            {
                // logging to file failed, we can't do anything better than return false 
                return false;
            }
        }

        /// <summary>
        /// To delete a file specified by a file name
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public override bool DeleteFile(string filename)
        {
            var fullPath = accomplishPath(filename);
            try
            {
                if (File.Exists(fullPath))
                    File.Delete(fullPath);
                return true;
            }
            catch (IOException ex)
            {
                return false;
            }
        }

        /// <summary>
        /// To get the file size in Kb
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public override long GetFileSizeKb(string fileName)
        {
            var fullPath = accomplishPath(fileName);
            try
            {
                if (File.Exists(fullPath))
                {
                    var fi = new FileInfo(fullPath);
                    return Convert.ToInt64(Math.Round((double)fi.Length / (double)1024));
                }
                return -1;
            }
            catch (IOException ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// To get the next file name
        /// </summary>
        /// <param name="logFileNameBase"></param>
        /// <returns></returns>
        public override string GetNextAvailableFileName(string logFileNameBase)
        {
            string theFileName = "";
            int i = 1;
            while (String.IsNullOrEmpty(theFileName))
            {
                var fn = String.Format("{0}{1}.log", logFileNameBase, i);
                if (File.Exists(accomplishPath(fn)))
                    i++;
                else
                    theFileName = fn;
            }
            return theFileName;
        }

        /// <summary>
        /// To load details of a file specified by the file name
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public override string LoadFromFile(string filename)
        {
            try
            {
                var fullPath = accomplishPath(filename);
                if (File.Exists(fullPath))
                    return File.ReadAllText(fullPath);
                return "";
            }
            catch (Exception ex)
            {
                // file read failed, return empty string
                return "";
            }
        }

        /// <summary>
        /// Save the log in a file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public override bool SaveToFile(string filename, string message)
        {
            try
            {
                var fullPath = accomplishPath(filename);
                File.WriteAllText(fullPath, message);
                return true;
            }
            catch (System.IO.IOException ex)
            {
                // logging to file failed, we can't do anything better than return false 
                return false;
            }
        }

    }
}