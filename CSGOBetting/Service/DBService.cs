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

        public static match GetOrCreateMatch(int matchid, DateTime? datetime = null, string team1 = "", string team2 = "", int roster1id = 0, int roster2id = 0, int matchstatus = 1)
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
    }
}
