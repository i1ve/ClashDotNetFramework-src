using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace ClashDotNetFramework.Utils
{
    public static class ProfileHelper
    {
        public struct ProfileDetail
        {
            public int ProxyCount { get; set; }

            public int GroupCount { get; set; }

            public int RuleCount { get; set; }
        }

        public static ProfileDetail GetProfileDetail(string yaml)
        {
            var deserializer = new DeserializerBuilder().Build();
            var result = deserializer.Deserialize<object>(yaml) as Dictionary<object, object>;
            var proxies = result["proxies"] as List<object>;
            var proxyGroups = result["proxy-groups"] as List<object>;
            var rules = result["rules"] as List<object>;
            ProfileDetail profileDetail = new ProfileDetail
            {
                ProxyCount = proxies.Count,
                GroupCount = proxyGroups.Count,
                RuleCount = rules.Count
            };
            return profileDetail;
        }

        public static ProfileDetail GetProfileDetailFromFile(string path)
        {
            string yaml = File.ReadAllText(path);
            return GetProfileDetail(yaml);
        }
    }
}
