using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotLibrary.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<Permission> Permissions { get; set; }
    }
}
