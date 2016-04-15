using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Entities.Setup;
using Domain.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DTO.DTOModels
{
    public class VacancyDTO
    {
        public int Id { get; set; }
        public DateTime EditTime { get; set; }
        public EntityState State { get; set; }
        public string Title { get; set; }
        public Level Level { get; set; }
        public string Description { get; set; }
        public int TeamId { get; set; }
        public int CityId { get; set; }
        public User Responsible { get; set; }
        public List<int> RequiredSkillsIds { get; set; }
        public int SalaryMin { get; set; }
        public int SalaryMax { get; set; }
        public LanguageSkillDTO LanguageSkill { get; set; }
        public TypeOfEmployment TypeOfEmployment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        [JsonIgnore]
        public List<VacancyStageInfo> CandidatesProgress { get; set; }
        public Vacancy ParentVacancy { get; set; }
        public List<File> Files { get; set; }
        public List<Comment> Comments { get; set; }
    }
}