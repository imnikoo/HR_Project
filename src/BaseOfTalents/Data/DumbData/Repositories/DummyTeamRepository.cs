using Domain.Entities.Setup;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DumbData.Repositories
{
    public class DummyTeamRepository : DummyBaseEntityRepository<Team>, ITeamRepository
    {
        public DummyTeamRepository(DummyBotContext context) : base(context)
        {
            Collection = _context.Teams;
        }
    }
}
