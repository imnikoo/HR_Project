using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotLibrary.Entities
{
    public class CandidateStageInfo : BaseEntity
    {
        public Candidate Candidate { get; set; }
        public List<StageInfo> StageInfos { get; set; }
    }
}