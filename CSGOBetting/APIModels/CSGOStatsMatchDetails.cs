using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGOBetting.APIModels
{
    class CSGOStatsMatchDetails
    {
    }

    public class Previous1
    {
        public int csgolid { get; set; }
        public string bestof { get; set; }
        public string winner { get; set; }
        public string Time { get; set; }
        public string team1 { get; set; }
        public string odds1 { get; set; }
        public string team2 { get; set; }
        public string odds2 { get; set; }
    }

    public class Previous2
    {
        public string csgolid { get; set; }
        public string bestof { get; set; }
        public string winner { get; set; }
        public string time { get; set; }
        public string team1 { get; set; }
        public string odds1 { get; set; }
        public string team2 { get; set; }
        public string odds2 { get; set; }
    }

    public class Prevmatchup
    {
        public string csgolid { get; set; }
        public string bestof { get; set; }
        public string winner { get; set; }
        public string time { get; set; }
        public string localtime { get; set; }
        public string team1 { get; set; }
        public string odds1 { get; set; }
        public string team2 { get; set; }
        public string odds2 { get; set; }
    }

    public class Csgol
    {
        public string csgolid { get; set; }
        public string time { get; set; }
        public string @event { get; set; }
        public string bestof { get; set; }
        public string team1 { get; set; }
        public string team2 { get; set; }
        public string odds1 { get; set; }
        public string odds2 { get; set; }
        public object roster1 { get; set; }
        public object roster2 { get; set; }
        public string winner { get; set; }
        public string note { get; set; }
        public string free { get; set; }
        public string localtime { get; set; }
        public List<Previous1> previous1 { get; set; }
        public List<Previous2> previous2 { get; set; }
        public List<Prevmatchup> prevmatchup { get; set; }
    }

    public class Hltv
    {
        public string team1 { get; set; }
        public string team2 { get; set; }
        public string hltvid { get; set; }
        public int egb1 { get; set; }
        public int id1 { get; set; }
        public int odds1 { get; set; }
        public int egb2 { get; set; }
        public int id2 { get; set; }
        public int odds2 { get; set; }
        public int roster1 { get; set; }
        public int roster2 { get; set; }
    }
    public class Map
    {
        public string __invalid_name__1 { get; set; }
        public string __invalid_name__2 { get; set; }
        public string __invalid_name__3 { get; set; }
        public string __invalid_name__4 { get; set; }
        public string __invalid_name__5 { get; set; }
    }
    public class Esls
    {
        public string team1 { get; set; }
        public string team2 { get; set; }
        public string time { get; set; }
        public List<string> score1 { get; set; }
        public List<string> score2 { get; set; }
        public Map map { get; set; }
    }
    public class Pvpme
    {
        public string team1 { get; set; }
        public string team2 { get; set; }
        public string pvpmeid { get; set; }
        public int odds1 { get; set; }
        public int odds2 { get; set; }
        public int percent1 { get; set; }
        public int percent2 { get; set; }
    }

    public class Reddit
    {
        public string permalink { get; set; }
        public int post { get; set; }
    }

    public class Elo1
    {
        public string elo { get; set; }
        public string matches { get; set; }
        public int odds { get; set; }
    }

    public class Elo2
    {
        public string elo { get; set; }
        public string matches { get; set; }
        public int odds { get; set; }
    }

    public class Players1
    {
        public string hltvid { get; set; }
        public string name { get; set; }
        public string rating { get; set; }
        public string hsr { get; set; }
        public string kdr { get; set; }
    }

    public class Players2
    {
        public string hltvid { get; set; }
        public string name { get; set; }
        public string rating { get; set; }
        public string hsr { get; set; }
        public string kdr { get; set; }
    }
    public class Matchstats
    {
        public string roster1 { get; set; }
        public string roster2 { get; set; }
        public Elo1 elo1 { get; set; }
        public Elo2 elo2 { get; set; }
        public List<Players1> players1 { get; set; }
        public List<Players2> players2 { get; set; }
        public string playeravg1 { get; set; }
        public string playeravg2 { get; set; }
        //public Mapwins1 mapwins1 { get; set; }
        //public Mapwins2 mapwins2 { get; set; }
    }

    public class RootObject
    {
        public Csgol csgol { get; set; }
        public Hltv hltv { get; set; }
        public Esls esls { get; set; }
        public Pvpme pvpme { get; set; }
        public Reddit reddit { get; set; }
        public Matchstats matchstats { get; set; }
    }
}
