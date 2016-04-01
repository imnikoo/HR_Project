using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace BotLibrary.Entities
{
    [ComplexType]
    public class File
    {
        public string FilePath { get; set; }
        public string Description { get; set; }
    }
}
