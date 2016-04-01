using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotLibrary.Entities
{
    [ComplexType]
    public class CandidateStageInfo
    {
        public Candidate Candidate { get; set; }
        public List<StageInfo> StageInfos { get; set; }
    }
}