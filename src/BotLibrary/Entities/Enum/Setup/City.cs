using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotLibrary.Entities.Setup
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public virtual Country Country { get; set; }
    }
}
