using BotLibrary.Entities.Enum;
using BotLibrary.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotLibrary.Entities
{
    public class LanguageSkill : BaseEntity
    {
        public Language Language { get; set; }
        public LanguageLevel LanguageLevel { get; set; }
    }
}
