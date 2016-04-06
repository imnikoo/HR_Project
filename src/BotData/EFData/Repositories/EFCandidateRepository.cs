using BotLibrary.Entities;
using BotLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BotData.EFData.Repositories
{
    public class EFCandidateRepository : EFBaseEntityRepository, ICandidateRepository
    {
        public void Add(Candidate entity)
        {
            _context.Candidates.Add(entity);
            _context.SaveChanges();
        }

        public IQueryable<Candidate> FindBy(Expression<Func<Candidate, bool>> predicate)
        {
            return _context.Candidates.Where(predicate);
        }

        public Candidate Get(int id)
        {
            return _context.Candidates.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Candidate> GetAll()
        {
            return _context.Candidates.AsQueryable();
        }

        public void Remove(Candidate entity)
        {
            entity.State = BotLibrary.Entities.Enum.EntityState.Inactive;
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Update(Candidate entity)
        {
            var attachedEntity = _context.Candidates.Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
