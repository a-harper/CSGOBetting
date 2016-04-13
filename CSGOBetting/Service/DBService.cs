using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGOBetting.Service
{
    class DBService
    {
        public team GetOrCreateTeam(string teamname)
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
    }
}
