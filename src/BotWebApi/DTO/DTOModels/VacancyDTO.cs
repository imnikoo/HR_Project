using BotLibrary.Entities;
using BotLibrary.Entities.Enum;
using BotLibrary.Entities.Setup;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotWebApi.DTO.DTOModels
{
    public class VacancyDTO
    {
        public int Id { get; set; }
        public DateTime EditTime { get; set; }
        public EntityState State { get; set; }
        public string Title { get; set; }
        public Level Level { get; set; }
        public string Description { get; set; }
        public Team Team { get; set; }
        public virtual Location Location { get; set; }
        public User Responsible { get; set; }
        public List<Skill> RequiredSkills { get; set; }
        public int SalaryMin { get; set; }
        public int SalaryMax { get; set; }
        public LanguageSkill LanguageSkill { get; set; }
        public TypeOfEmployment TypeOfEmployment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public List<VacancyStageInfo> CandidatesProgress { get; set; }
        public Vacancy ParentVacancy { get; set; }
        public List<File> Files { get; set; }
        public List<Comment> Comments { get; set; }
    }
}