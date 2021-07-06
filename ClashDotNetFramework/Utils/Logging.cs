using ClashDotNetFramework.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashDotNetFramework.Utils
{
    public class Logging
    {
        public static string LogFile = Path.Combine(Utils.GetClashLogsDir(), "Application.log");

        private static readonly object FileLock = new object();

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="text">日志内容</param>
        /// <param name="logLevel">日志等级</param>
        private static void Write(string text, LogLevel logLevel)
        {
            lock (FileLock)
                File.AppendAllText(LogFile, $@"[{DateTime.Now}][{logLevel}] {text}{Global.EOF}");
        }

        /// <summary>
        /// 写Info级别的日志
        /// </summary>
        /// <param name="text">日志</param>
        public static void Info(string text)
        {
            Write(text, LogLevel.INFO);
        }

        /// <summary>
        /// 写WARNING级别的日志
        /// </summary>
        /// <param name="text">日志</param>
        public static void Warning(string text)
        {
            Write(text, LogLevel.WARNING);
        }

        /// <summary>
        /// 写ERROR级别的日志
        /// </summary>
        /// <param name="text">日志</param>
        public static void Error(string text)
        {
            Write(text, LogLevel.ERROR);
        }
    }
}
