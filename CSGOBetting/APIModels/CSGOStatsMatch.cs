using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGOBetting.APIModels
{
    class CSGOStatsMatch
    {
        public int CSGOlid { get; set; }
        public DateTime Time { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Winner { get; set; }
    }
}
