using BotData.Abstract;
using BotLibrary.Entities;
using BotLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotData.DumbData.Repositories
{
    class DummyUserRepository : DummyBaseEntityRepository<User>, IUserRepository
    {
        public DummyUserRepository(DummyBotContext context) : base(context)
        {

        }
       
    }
}
