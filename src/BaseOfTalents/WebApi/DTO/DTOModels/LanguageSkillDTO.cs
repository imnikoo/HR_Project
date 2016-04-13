using Domain.Entities.Enum;
using Domain.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DTO.DTOModels
{
    public class LanguageSkillDTO
    {
        public int Id { get; set; }
        public DateTime EditTime { get; set; }
        public EntityState State { get; set; }
        public int LanguageId { get; set; }
        public LanguageLevel LanguageLevel { get; set; }
    }
}