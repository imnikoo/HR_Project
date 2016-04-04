using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotLibrary.Entities
{
    public class VacancyStageInfo : BaseEntity
    {
        public Vacancy Vacancy { get; set; }
        public List<StageInfo> StageInfos { get; set; }
    }
}