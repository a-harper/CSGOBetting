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
    static class DataService
    {
        public static int GetTodaysMatches()
        {
            var api = new APIService(Settings.MatchStatsAPIMatches);
            string jsonMatches = api.GetResponse();
            try
            {
                JObject csgostatsMatches = JObject.Parse(jsonMatches);
                IList<JToken> results = csgostatsMatches["upcoming"].Children().ToList();

                // Serialize
                IList<CSGOStatsMatch> matches =
                    results.Select(result => JsonConvert.DeserializeObject<CSGOStatsMatch>(result.ToString())).ToList();

                using (var ctx = new dbEntities())
                {
                    foreach (CSGOStatsMatch m in matches)
                    {
                        match matchEntity = DBService.GetOrCreateMatch(m.CSGOlid, m.Time, m.Team1, m.Team2);
                    }
                }

            }
            catch
            {
                return 0;
            }
            
            return 1;
        }
    }
}
