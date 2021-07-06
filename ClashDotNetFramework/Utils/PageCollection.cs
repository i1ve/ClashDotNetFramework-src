using ClashDotNetFramework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashDotNetFramework.Utils
{
    public class PageCollection
    {
        public OverviewPage overviewPage;

        public ProxiesPage proxiesPage;

        public ProfilesPage profilesPage;

        public RulesPage rulesPage;

        public ConnectionsPage connectionsPage;

        public LogsPage logsPage;

        public SettingsPage settingsPage;

        public SupportPage supportPage;

        public void Init()
        {
            overviewPage = new OverviewPage();
            proxiesPage = new ProxiesPage();
            profilesPage = new ProfilesPage();
            rulesPage = new RulesPage();
            connectionsPage = new ConnectionsPage();
            logsPage = new LogsPage();
            settingsPage = new SettingsPage();
            supportPage = new SupportPage();
        }
    }
}
