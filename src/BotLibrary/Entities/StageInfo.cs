using BotLibrary.Entities.Setup;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotLibrary.Entities
{
    public class StageInfo : BaseEntity
    {
        public Stage Stage { get; set; }
        public Comment Comment { get; set; }
    }
}
