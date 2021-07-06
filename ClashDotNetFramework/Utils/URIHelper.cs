using ClashDotNetFramework.Models.Enums;
using ClashDotNetFramework.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Threading;

namespace ClashDotNetFramework.Utils
{
    public static class URIHelper
    {
        public static void ProcessURI(string data)
        {
            try
            {
                Uri uri = new Uri(data);
                // 处理Sccheme部分, clash://
                switch (uri.Scheme)
                {
                    case "clash":
                        // 处理Path部分, clash://install-config
                        switch (uri.Authority)
                        {
                            case "install-config":
                                string url = HttpUtility.ParseQueryString(uri.Query).Get("url");
                                if (!string.IsNullOrWhiteSpace(url))
                                {
                                    Task.Run(() =>
                                    {
                                        Uri profileUri = new Uri(Uri.UnescapeDataString(url));
                                        ProfileItem profileItem = new ProfileItem
                                        {
                                            Type = ProfileType.Remote,
                                            IsRemote = true,
                                            Host = profileUri.Host,
                                            Url = profileUri.AbsoluteUri,
                                            UpdateInterval = 0,
                                            LastUpdate = DateTime.Now
                                        };
                                        if (profileItem.Update())
                                        {
                                            Application.Current.Dispatcher.Invoke(new Action(() =>
                                            {
                                                Global.Settings.Profile.Add(profileItem);
                                            }));
                                            Configuration.Save();
                                        }
                                    });
                                }
                                return;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                // Probably not URI at all
            }
        }
    }
}
