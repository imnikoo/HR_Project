using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Entities.Setup;
using Domain.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.DTO.DTOModels
{
    public class CandidateDTO
    {
        public CandidateDTO(Candidate candidate)
        {
            Skype = candidate.Skype;
            BirthDate = candidate.BirthDate;
            Comments = candidate.Comments;
            Description = candidate.Description;
            Education = candidate.Education;
            Email = candidate.Email;
            ExperienceId = candidate.Experience == null ? 0 : candidate.Experience.Id;
            Files = candidate.Files;
            Sources = candidate.Sources;
            FirstName = candidate.FirstName;
            IsMale = candidate.IsMale;
            LanguageSkills = candidate.LanguageSkills.Select(x=>new LanguageSkillDTO(x)).ToList();
            LastName = candidate.LastName;
            CityId = candidate.City == null ? 0 : candidate.City.Id;
            MiddleName = candidate.MiddleName;
            PhoneNumbers = candidate.PhoneNumbers;
            Photo = candidate.Photo;
            PositionDesired = candidate.PositionDesired;
            Practice = candidate.Practice;
            RelocationAgreement = candidate.RelocationAgreement;
            SalaryDesired = candidate.SalaryDesired;
            SkillsIds = candidate.Skills.Select(x=> x.Id).ToList();
            SocialNetworks = candidate.SocialNetworks.Select(x=> new CandidateSocialDTO(x)).ToList();
            TypeOfEmployment = candidate.TypeOfEmployment;
            VacanciesProgress = candidate.VacanciesProgress;
        }

        public CandidateDTO()
        {
            PhoneNumbers = new List<string>();
            SkillsIds = new List<int>();
            SocialNetworks = new List<CandidateSocialDTO>();
            LanguageSkills = new List<LanguageSkillDTO>();
            Files = new List<File>();
            VacanciesProgress = new List<VacancyStageInfo>();
            Comments = new List<Comment>();
            Sources = new List<CandidateSource>();
        }

        public int Id { get; set; }
        public DateTime EditTime { get; set; }
        public EntityState State { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public bool IsMale { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual Photo Photo { get; set; }
        public List<string> PhoneNumbers { get; set; }
        [Required]
        public string Email { get; set; }
        public string Skype { get; set; }
        public string PositionDesired { get; set; }
        public int SalaryDesired { get; set; }
        public virtual ICollection<int> SkillsIds { get; set; }
        public TypeOfEmployment TypeOfEmployment { get; set; }
        public string Practice { get; set; }
        public int ExperienceId { get; set; }
        public string Description { get; set; }
        public virtual int CityId { get; set; }
        public bool RelocationAgreement { get; set; }
        public virtual ICollection<CandidateSocialDTO> SocialNetworks { get; set; }
        public string Education { get; set; }
        public virtual ICollection<LanguageSkillDTO> LanguageSkills { get; set; }
        public virtual ICollection<File> Files { get; set; }
        [JsonIgnore]
        public virtual ICollection<VacancyStageInfo> VacanciesProgress { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CandidateSource> Sources { get; set; }

    }
}