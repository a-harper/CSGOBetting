using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSGOBetting.Service
{
    static class DBService
    {
        public static team GetOrCreateTeam(string teamname)
        {
            using (var ctx = new dbEntities())
            {
                team teamEntity = (from c in ctx.teams
                    where c.teamname == teamname
                    select c).SingleOrDefault();
                if (teamEntity != null) return teamEntity;
                var newTeam = new team {teamname = teamname};
                ctx.teams.Add(newTeam);
                ctx.SaveChanges();
                teamEntity = (from c in ctx.teams
                    where c.teamname == teamname
                    select c).SingleOrDefault();
                return teamEntity;
            }
        }

        public static match GetOrCreateMatch(int matchid, DateTime? datetime = null, string team1 = "", string team2 = "", string winner = "", int roster1id = 0, int roster2id = 0,  int matchstatus = 1)
        {
            using (var ctx = new dbEntities())
            {
                match matchEntity = (from c in ctx.matches
                    where c.matchid == matchid
                    select c).SingleOrDefault();
                if (matchEntity != null) return matchEntity;
                if (datetime == null)
                {
                    throw new ArgumentNullException();
                }
                var time = (DateTime) datetime;
                var newMatch = new match
                {
                    matchid = matchid,
                    csgolid = matchid,
                    datetime = time.ToString("s", System.Globalization.CultureInfo.InvariantCulture),
                    team1id = GetOrCreateTeam(team1).teamid,
                    team2id = GetOrCreateTeam(team2).teamid,
                    roster1id = roster1id,
                    roster2id = roster2id,
                    winner = GetOrCreateTeam(winner).teamid,
                    matchstatus = matchstatus
                };
                ctx.matches.Add(newMatch);
                ctx.SaveChanges();

                matchEntity = (from c in ctx.matches
                    where c.matchid == matchid
                    select c).SingleOrDefault();
                return matchEntity;
            }
        }

        public static player GetOrCreatePlayer(int hltvid, string name = "", float rating = 0, float hsr = 0,
            float kdr = 0)
        {
            using (var ctx = new dbEntities())
            {
                player playerEntity = (from c in ctx.players
                    where c.hltvid == hltvid
                    select c).SingleOrDefault();
                if (playerEntity != null) return playerEntity;
                var newPlayer = new player
                {
                    hltvid = hltvid,
                    name = name,
                    rating = rating,
                    hsr = hsr,
                    kdr = kdr
                };
                ctx.players.Add(newPlayer);
                ctx.SaveChanges();

                playerEntity = (from c in ctx.players
                    where c.hltvid == hltvid
                    select c).SingleOrDefault();
                return playerEntity;
            }
        }
    }
}
