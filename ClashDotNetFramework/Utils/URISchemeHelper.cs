using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URIScheme;

namespace ClashDotNetFramework.Utils
{
    public class URISchemeHelper
    {
        private static string key = "clash";
        private static URISchemeService service = new URISchemeService(key, @"Clash .NET Framework", System.Reflection.Assembly.GetEntryAssembly().Location);

        public static bool Check()
        {
            return service.Check();
        }

        public static void Set()
        {
            service.Set();
        }

        public static void Delete()
        {
            service.Delete();
        }
    }
}
