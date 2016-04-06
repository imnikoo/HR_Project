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
    public class EFBaseEntityRepository
    {
        protected BOTContext _context = new BOTContext();

    }
}
