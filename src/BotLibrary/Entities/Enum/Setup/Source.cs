using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotLibrary.Entities.Setup
{
    [ComplexType]
    public class Source
    {
        public String Title { get; set; }
        public String Url { get; set; }
    }
}
