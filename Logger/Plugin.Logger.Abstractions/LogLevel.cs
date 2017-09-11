using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Logger.Abstractions
{
    /// <summary>
    /// Contains levels of Logs
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// logs all records
        /// </summary>
        All = 0,
        /// <summary>
        ///  logs debug
        /// </summary>
        Debug = 1,
        /// <summary>
        /// logs info, warning and error records
        /// </summary>
        Info = 2,
        /// <summary>
        /// logs warning and error records
        /// </summary>
        Warning = 3,
        /// <summary>
        /// logs only error records
        /// </summary>
        Error = 4
    }
}
