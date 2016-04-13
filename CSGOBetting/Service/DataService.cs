using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CSGOBetting.App_Code;
using CSGOBetting.APIModels;
using CSGOBetting.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSGOBetting.Service
{
    enum MatchType
    {
        Live,
        Upcoming,
        Previous
    }
    static class DataService
    {
        public static int GetTodaysMatches(MatchType mt)
        {
            var api = new APIService(Settings.MatchStatsAPIMatches);
            string jsonMatches = api.GetResponse();
            try
            {
                JObject csgostatsMatches = JObject.Parse(jsonMatches);
                IList<JToken> results = csgostatsMatches[mt.ToString().ToLower()].Children().ToList();

                // Serialize
                IList<CSGOStatsMatch> matches =
                    results.Select(result => JsonConvert.DeserializeObject<CSGOStatsMatch>(result.ToString())).ToList();

                foreach (CSGOStatsMatch m in matches)
                {
                    match matchEntity = DBService.GetOrCreateMatch(m.CSGOlid, m.Time, m.Team1, m.Team2, m.Winner);
                }


            }
            catch
            {
                return 0;
            }
            
            return 1;
        }

        public static int GetMatchDetails(int matchid)
        {
            var api = new APIService(Settings.CSGOLoungeURL + matchid);
            string jsonMatchDetails = api.GetResponse();
            try
            {
                //JObject csgostatsMatchDetails = JObject.Parse(jsonMatchDetails);
                var matchDetails =
                    JsonConvert.DeserializeObject<CSGOStatsMatchDetails>(jsonMatchDetails);
            }
            catch
            {
                return 0;
            }
            return 1;
        }
    }
}
