using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Entities.Setup;
using Domain.Repositories;
using System.Linq.Expressions;
using System;
using System.Data.Entity;
using System.Linq;

namespace Data.EFData.Repositories
{
    public class EFCandidateRepository : EFBaseEntityRepository<Candidate>, ICandidateRepository
    {
        public override IQueryable<Candidate> GetAll()
        {
            return _context.Candidates
                .Include("SocialNetworks.SocialNetwork")
                .Include(x=>x.VacanciesProgress)
                .Include(x => x.Skills)
                .Include(x => x.Experience)
                .Include(x => x.City)
                .Include(x => x.LanguageSkills)
                .Include(x => x.Files)
                .Include(x => x.Comments)
                .Include(x => x.Sources);
        }
    }
}
