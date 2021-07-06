using ClashDotNetFramework.Models;
using ClashDotNetFramework.Models.Items;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashDotNetFramework.Utils
{
    public static class Configuration
    {
        public static string DATA_DIR = Path.Combine(Utils.GetClashConfigDir(), "data");

        public static readonly string SETTINGS_JSON = Path.Combine(DATA_DIR, "settings.json");

        public static void Load()
        {
            if (Directory.Exists(DATA_DIR) && File.Exists(SETTINGS_JSON))
            {
                try
                {
                    var settingJObject = (JObject)JsonConvert.DeserializeObject(File.ReadAllText(SETTINGS_JSON));
                    Global.Settings = settingJObject?.ToObject<Setting>() ?? new Setting();
                    Global.Settings.Profile.Clear();

                    if (settingJObject?["Profile"] != null)
                    {
                        foreach (JObject server in settingJObject["Profile"])
                        {
                            var profileResult = server.ToObject<ProfileItem>();
                            if (profileResult != null)
                                Global.Settings.Profile.Add(profileResult);
                        }
                    }

                    CheckAll();
                    Save();
                }
                catch
                {
                }
            }
            else
            {
                CheckAll();
                Save();
            }
        }

        public static void Save()
        {
            if (!Directory.Exists(DATA_DIR))
            {
                Directory.CreateDirectory(DATA_DIR);
            }

             File.WriteAllText(SETTINGS_JSON, JsonConvert.SerializeObject(Global.Settings, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }

        #region Check Methods

        private static void CheckAll()
        {
            CheckProfile();
            CheckMMDB();
            CheckNetFilter();
        }

        private static void CheckProfile()
        {
            // 如果用户没有配置文件, 新建一个
            if (Global.Settings.Profile.Count == 0)
            {
                string path = ConfigHelper.GenerateClashConfig();
                ProfileItem profileItem = new ProfileItem
                {
                    Name = "config.yaml",
                    FileName = path,
                    IsSelected = true
                };
                Global.Settings.Profile.Add(profileItem);
            }
            // 如果用户所有配置文件都没有选中, 选中最后一个
            if (Global.Settings.Profile.FirstOrDefault(p => p.IsSelected == true) == null)
            {
                Global.Settings.Profile.Last().IsSelected = true;
            }
        }

        private static void CheckMMDB()
        {
            // MMDB文件位置
            string path = Path.Combine(Utils.GetClashConfigDir(), "Country.mmdb");
            // 没有MMDB文件就复制一个过去
            if (!File.Exists(path))
            {
                string sourcePath = Path.Combine(Global.ClashDotNetFrameworkDir, "bin\\Country.mmdb");
                File.Copy(sourcePath, path);
            }
        }

        private static void CheckNetFilter()
        {
            if (Global.Settings.RedirectTraffic.Count == 0)
            {
                Global.Settings.RedirectTraffic.Add("TCP");
                Global.Settings.RedirectTraffic.Add("UDP");
            }
            if (Global.Settings.Processes.Count == 0)
            {
                Global.Settings.Processes.Add("ClashDotNetFramework.exe");
                Global.Settings.Processes.Add("Clash.exe");
                Global.Settings.Processes.Add("Redirector.exe");
            }
            if (Global.Settings.BypassType.Count == 0)
            {
                Global.Settings.BypassType.Add("LOCAL");
                Global.Settings.BypassType.Add("LAN");
            }
        }

        #endregion
    }
}
