using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace BotLibrary.Entities
{
    public class File : BaseEntity
    {
        public string FilePath { get; set; }
        public string Description { get; set; }
    }
}
