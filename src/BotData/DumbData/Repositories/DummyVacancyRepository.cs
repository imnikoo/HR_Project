using BotData.Abstract;
using BotLibrary.Entities;
using BotLibrary.Repositories;
using System.Collections.Generic;

namespace BotData.DumbData.Repositories
{
    public class DummyVacancyRepository : DummyBaseEntityRepository<Vacancy>, IVacancyRepository
    {
        public DummyVacancyRepository(DummyBotContext context) : base(context)
        {
            Collection = _context.Vacancies;
        }
    }
}
