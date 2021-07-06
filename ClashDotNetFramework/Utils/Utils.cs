using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace ClashDotNetFramework.Utils
{
    public class Utils
    {
        /// <summary>
        /// 获取当前用户目录
        /// </summary>
        /// <returns>获取当前用户目录</returns>
        public static string GetUserDir()
        {
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Directory.GetParent(path).ToString();
            }
            return path;
        }

        /// <summary>
        /// 获取Clash配置目录
        /// </summary>
        /// <returns>Clash配置目录</returns>
        public static string GetClashConfigDir()
        {
            string path = Path.Combine(GetUserDir(), ".config\\clash");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        /// <summary>
        /// 获取Clash配置文件目录
        /// </summary>
        /// <returns>Clash配置文件目录</returns>
        public static string GetClashProfilesDir()
        {
            string path = Path.Combine(GetClashConfigDir(), "profiles");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        /// <summary>
        /// 获取Clash日志文件目录
        /// </summary>
        /// <returns>Clash日志文件目录</returns>
        public static string GetClashLogsDir()
        {
            string path = Path.Combine(GetClashConfigDir(), "logs");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        /// <summary>
        /// 获取文件SHA256
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static string SHA256CheckSum(string filePath)
        {
            try
            {
                var sha256 = SHA256.Create();
                var fileStream = File.OpenRead(filePath);
                return sha256.ComputeHash(fileStream).Aggregate(string.Empty, (current, b) => current + b.ToString("x2"));
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 获取文件版本
        /// </summary>
        /// <param name="file">文件名称</param>
        /// <returns></returns>
        public static string GetFileVersion(string file)
        {
            return File.Exists(file) ? FileVersionInfo.GetVersionInfo(file).FileVersion : string.Empty;
        }
    }
}
