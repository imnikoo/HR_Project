using BotLibrary.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotLibrary.Entities
{
    public class CandidateSocial : BaseEntity
    {
        public virtual SocialNetwork SocialNetwork { get; set; }
        public string Path { get; set; }
    }
}
