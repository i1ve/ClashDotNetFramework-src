using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashDotNetFramework.Utils
{
    public class ConfigHelper
    {
        public static string GenerateClashConfig()
        {
            byte[] data = Convert.FromBase64String("IyDmt7flkIjku6PnkIbnq6/lj6MKbWl4ZWQtcG9ydDogMTEyMjMKCiMg5YWB6K645bGA5Z+f572R55qE6L+e5o6lCmFsbG93LWxhbjogdHJ1ZQoKIyBDbGFzaCDnmoQgUkVTVGZ1bCBBUEkKZXh0ZXJuYWwtY29udHJvbGxlcjogJzEyNy4wLjAuMTo5MDkwJwoKIyBSRVNUZnVsIEFQSSDnmoTlj6Pku6QKc2VjcmV0OiAnJw==");
            string decodedString = Encoding.UTF8.GetString(data);
            string path = Path.Combine(Utils.GetClashConfigDir(), "config.yaml");
            File.WriteAllText(path, decodedString);
            return path;
        }
    }
}
