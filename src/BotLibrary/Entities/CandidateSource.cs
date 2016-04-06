using BotLibrary.Entities.Enum;

namespace BotLibrary.Entities
{
    public class CandidateSource : BaseEntity
    {
        public Source Source { get; set; }
        public string Path { get; set; }
    }
}
