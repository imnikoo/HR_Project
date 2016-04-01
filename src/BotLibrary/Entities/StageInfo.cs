using BotLibrary.Entities.Setup;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotLibrary.Entities
{
    public class StageInfo
    {
        public Stage Stage { get; set; }
        public Comment Comment { get; set; }
    }
}
