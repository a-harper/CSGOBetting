using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CSGOBetting.App_Code
{
    static class Settings
    {
        public static string CSGOLoungeURL => ConfigurationManager.AppSettings["CSGOLoungeURL"];
        public static string MatchStatsAPIMatches => ConfigurationManager.AppSettings["MatchStatsAPIMatches"];
        public static string MatchStatsAPISpecificMatch
            => ConfigurationManager.AppSettings["MatchStatsAPISpecificMatch"];
    }
}
