using BotLibrary.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BotData.Abstract
{
    public interface IContext
    {
        IEnumerable<Candidate> Candidates { get; set; }
        IEnumerable<Vacancy> Vacancies { get; set; }
    }
}
