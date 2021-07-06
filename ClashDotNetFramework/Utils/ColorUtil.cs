using ClashDotNetFramework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ClashDotNetFramework.Utils
{
    public static class ColorUtil
    {
        public static void GenerateRandomColor()
        {
            switch (Global.Settings.Theme)
            {
                case ThemeType.Classic:
                    Random random = new Random();
                    var r = 100 * random.NextDouble() + 10;
                    var g = 100 * random.NextDouble() + 10;
                    var b = 100 * random.NextDouble() + 10;
                    Global.ProxyColor = Color.FromRgb((byte)r, (byte)g, (byte)b);
                    break;
                default:
                    break;
            }
        }
    }
}
