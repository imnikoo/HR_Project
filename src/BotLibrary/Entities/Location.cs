using BotLibrary.Entities.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BotLibrary.Entities
{
    public class Location : BaseEntity
    {
        public virtual City City { get; set; }
    }
}
