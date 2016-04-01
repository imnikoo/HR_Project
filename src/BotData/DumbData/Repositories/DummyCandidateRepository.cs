using BotData.Abstract;
using BotLibrary.Entities;
using BotLibrary.Repositories;
using System.Data.Entity;

namespace BotData.DumbData.Repositories
{
    public class DummyCandidateRepository : DummyBaseEntityRepository<Candidate>, ICandidateRepository
    {
        public DummyCandidateRepository(DummyBotContext context) : base(context)
        {
            Collection = _context.Candidates;
        }
    }
}
