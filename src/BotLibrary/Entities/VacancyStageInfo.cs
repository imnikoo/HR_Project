using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotLibrary.Entities
{
    [ComplexType]
    public class VacancyStageInfo
    {
        public Vacancy Vacancy { get; set; }
        public List<StageInfo> StageInfos { get; set; }
    }
}